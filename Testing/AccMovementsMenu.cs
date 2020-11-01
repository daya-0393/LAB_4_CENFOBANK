using Entities_POJO;
using CoreAPI;
using WebAPI;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Controllers;
using System.Web.Http;
using System.Web.Http.Results;

namespace Testing
{
    class AccMovementsMenu
    {

        static void trimString(String[] strList)
        {
            var i = 0;
            foreach (var str in strList)
            {
                strList[i] = str.Trim();
                i++;
            }
        }

        public static void ControlAccMovements(Account account)
        {
            AccountMovement accMovement = new AccountMovement();
            var accMovController = new AccountMovController();
            accMovement.AccountNum = account.AccountNum;
            IHttpActionResult resp;
            var continuar = true;

            while (continuar)
            {
                try
                {
                    resp = accMovController.Get(accMovement);
                    var respContent = resp as OkNegotiatedContentResult<List<AccountMovement>>;
                    Console.WriteLine("************************************");
                    Console.WriteLine("----- MOVIMIENTOS DE LA CUENTA -----");
                    Console.WriteLine("************************************");
                    if (respContent != null)
                    {
                        if(respContent.Content.Count > 0)
                        {
                            foreach (AccountMovement mov in respContent.Content)
                            {
                                Console.WriteLine("MOV ===> " + mov.GetEntityInformation());
                            }
                        }
                    }
                    else
                    {
                        var errorMsg = resp as NegotiatedContentResult<string>;
                        Console.WriteLine(errorMsg.Content);
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Que desea realizar?");
                Console.WriteLine("1. Registrar movimiento a la cuenta");
                Console.WriteLine("2. Volver al menu de cuentas bancarias");

                Console.Write("Digite la opcion que desea: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("\n ***** Registrar nuevo movimiento en la cuenta *******" + '\n');
                        Console.WriteLine("Ingrese la siguiente informacion en el mismo orden y separado por comas");
                        Console.WriteLine("Fecha del movimiento (aaaa-mm-dd), Tipo de movimiento (C= Credito / D= Debito), Monto del movimiento");
                        var info = Console.ReadLine();
                        var infoArray = info.Split(',');
                        trimString(infoArray);
                        accMovement = new AccountMovement(infoArray, accMovement.AccountNum, account.UserId);
                        resp = accMovController.Post(accMovement, account);
                        var respContent = resp as OkNegotiatedContentResult<AccountMovement>;
                        if(respContent != null)
                        {
                            Console.WriteLine(respContent.Content.GetEntityInformation());
                        }
                        else
                        {
                            var errorMsg = resp as NegotiatedContentResult<string>;
                            Console.WriteLine(errorMsg.Content);
                        }
                        break;

                    case "2":
                        continuar = false;
                        break;
                }
            }
        }
    }
}
