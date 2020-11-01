using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities_POJO;
using CoreAPI;
using WebAPI.Controllers;
using System.Web.Http;
using System.Web.Http.Results;

namespace Testing
{
    class AccountMenu
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
        public static void ControlAccounts(string userId)
        {
            Account account = new Account();
            var accController = new AccountController();
            Random rand = new Random();
            IHttpActionResult resp;
            var continuar = true;
            while (continuar)
            {
                Console.WriteLine("***************************");
                Console.WriteLine("----- CUENTAS BANCARIAS -----");
                Console.WriteLine("***************************");
                account.UserId = userId;
                resp = accController.Get(account);
                var respContent = resp as OkNegotiatedContentResult<List<Account>>;
                var accountList = respContent.Content;

                if (accountList != null)
                {
                    foreach (var acc in accountList)
                    {
                        Console.WriteLine(" ==> CUENTA: " + acc.GetEntityInformation());
                    }
                }
                else
                {
                    Console.WriteLine("No existen cuentas bancarias registradas para este usuario");
                }

                Console.WriteLine("Que desea realizar?");
                Console.WriteLine("1. Ver movimientos de la cuenta bancaria");
                Console.WriteLine("2. Registrar cuenta bancaria");
                Console.WriteLine("3. Modificar cuenta bancaria");
                Console.WriteLine("4. Eliminar cuenta bancaria");
                Console.WriteLine("5. Volver al menu principal");
                Console.Write("Digite la opcion que desea: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        if(accountList.Count == 1)
                        {
                            AccMovementsMenu.ControlAccMovements(account);
                        }
                        else
                        {
                            Console.Write("Ingrese el numero de cuenta: ");
                            account.AccountNum = Convert.ToInt32(Console.ReadLine());
                            AccMovementsMenu.ControlAccMovements(account);
                        }
                        break;

                    case "2":
                        Console.WriteLine("\n ***** Registrar nueva cuenta bancaria *******" + '\n');
                        Console.WriteLine("Ingrese la siguiente informacion en el mismo orden y separado por comas");
                        Console.WriteLine("Cedula del usuario, Tipo de cuenta (A= Ahorros / C= Corriente), Moneda (C= Colon /D= Dolar), Saldo");
                        var info = Console.ReadLine();
                        var infoArray = info.Split(',');
                        trimString(infoArray);
                        var accountNum = rand.Next(1000, 9999);
                        account = new Account(infoArray, accountNum);
                        resp = accController.Post(account);
                        var creRespCont = resp as OkNegotiatedContentResult<string>;

                        if (creRespCont != null)
                        {
                            Console.WriteLine(creRespCont.Content);
                        }
                        else
                        {
                            var errorMsg = resp as NegotiatedContentResult<string>;
                            Console.WriteLine(errorMsg.Content);
                        }

                        break;

                    case "3":
                        Console.WriteLine("Ingrese la informacion actualizada");
                        Console.Write("Ingrese el numero de la cuenta a actualizar: ");
                        account.AccountNum = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Tipo de cuenta: ");
                        account.Type = Console.ReadLine();
                        Console.Write("Tipo de moneda: ");
                        account.Currency = Console.ReadLine();
                        Console.WriteLine("Saldo: ");
                        account.Balance = Convert.ToInt32(Console.ReadLine());

                        resp = accController.Put(account);
                        var updRespCont = resp as OkNegotiatedContentResult<string>;
                        if (updRespCont != null)
                        {
                            Console.WriteLine(updRespCont.Content);
                        }
                        else
                        {
                            var errorMsg = resp as NegotiatedContentResult<string>;
                            Console.WriteLine(errorMsg.Content);
                        }
                        
                        break;

                    case "4":
                        Console.Write("Digite el numero de cuenta a eliminar: ");
                        account.AccountNum = Convert.ToInt32(Console.ReadLine());
                        resp = accController.Delete(account);
                        var delRespCont = resp as OkNegotiatedContentResult<string>;

                        if (delRespCont != null)
                        {
                            Console.WriteLine(delRespCont.Content);
                        }
                        else
                        {
                            var errorMsg = resp as NegotiatedContentResult<string>;
                            Console.WriteLine(errorMsg.Content);
                        }

                        break;
                    case "5":
                        continuar = false;
                        break;
                }
            }
        }
    }
}
