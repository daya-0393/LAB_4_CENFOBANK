using System;
using System.Collections.Generic;
using Entities_POJO;
using WebAPI.Controllers;
using System.Web.Http;
using System.Web.Http.Results;

namespace Testing
{
    class CreditMenu
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

        public static void ControlCredits(string userId)
        {
            Credit credit = new Credit();
            Payment payment = new Payment();
            PaymentController paymentController = new PaymentController();
            CreditController creditController = new CreditController();
            IHttpActionResult resp;
            var continuar = true;

            while (continuar)
            {
                Console.WriteLine("***************************");
                Console.WriteLine("--------- CREDITOS --------");
                Console.WriteLine("***************************");
                credit.UserId = userId;
                resp = creditController.Get(credit);
                var listRespContent = resp as OkNegotiatedContentResult<List<Credit>>;

                if (listRespContent != null)
                {
                    foreach (var c in listRespContent.Content)
                    {
                        Console.WriteLine(" ==> CREDITO: " + c.GetEntityInformation());
                    }
                }
                else
                {
                    Console.WriteLine("No existen creditos registradas para este usuario");
                }
                Console.WriteLine("--------------------");
                Console.WriteLine("Que desea realizar?");
                Console.WriteLine("1. Registrar un nuevo credito");
                Console.WriteLine("2. Modificar credito");
                Console.WriteLine("3. Eliminar credito");
                Console.WriteLine("4. Ver pagos realizados");
                Console.WriteLine("5. Realizar pago");
                Console.WriteLine("6. Volver al menu principal");
                Console.Write("Digite la opcion que desea: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("\n ***** Registrar nueva credito *******" + '\n');
                        Console.WriteLine("Ingrese la siguiente informacion en el mismo orden y separado por comas");
                        Console.WriteLine("Monto, Tasa de interes, Nombre de la linea de credito, Cuota, Fecha de inicio (aaaa-mm-dd), Estado del credito");
                        var info = Console.ReadLine();
                        var infoArray = info.Split(',');
                        trimString(infoArray);
                        credit = new Credit(infoArray, credit.UserId);
                        resp = creditController.Post(credit);
                        var creRespCont = resp as OkNegotiatedContentResult<Credit>;
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
                    case "2":
                        Console.WriteLine("\n ***** Actualizar credito ***** \n");
                        Console.WriteLine("Ingrese la informacion actualizada");
                        Console.Write("Digite el id del credito a actualizar: ");
                        credit.CreditId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Tasa de interes: ");
                        credit.InterestRate = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Nombre de linea del credito: ");
                        credit.CreditLine = Console.ReadLine();
                        Console.Write("Cuota: ");
                        credit.Fee = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Fecha de inicio (aaaa-mm-dd): ");
                        credit.StartDate = Convert.ToDateTime(Console.ReadLine());
                        Console.Write("Estado del credito (A= Aprobado/ D= Denegado/ P= Pendiente): ");
                        credit.Status = Convert.ToChar(Console.ReadLine());

                        resp = creditController.Put(credit);
                        var updRespCont= resp as OkNegotiatedContentResult<string>;
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

                    case "3":
                        Console.WriteLine("\n ***** Eliminar credito ***** \n");
                        Console.Write("Digite el numero de cuenta a eliminar: ");
                        credit.CreditId = Convert.ToInt32(Console.ReadLine());
                        resp = creditController.Delete(credit);
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

                    case "4":
                        Console.WriteLine("\n ***** Pagos realizados ***** \n");
                        Console.Write("Ingrese el id del credito a consultar: ");
                        payment.CreditId = Convert.ToInt32(Console.ReadLine());
                        
                        resp = paymentController.Get(payment);
                        var paymRespContent = resp as OkNegotiatedContentResult<List<Payment>>;

                        if (paymRespContent != null)
                        {
                            foreach (var c in paymRespContent.Content)
                            {
                                Console.WriteLine(" ==> PAGO: " + c.GetEntityInformation());
                            }
                        }
                        else
                        {
                            var errorMsg = resp as NegotiatedContentResult<string>;
                            Console.WriteLine(errorMsg.Content);
                        }
                        break;

                    case "5":
                        Console.WriteLine("\n ***** Hacer pago *******" + '\n');
                        Console.WriteLine("Digite el id del credito al cual va a realizar el pago");
                        credit.CreditId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese la siguiente informacion en el mismo orden y separado por comas");
                        Console.WriteLine("Fecha de pago (aaaa-mm-dd), Monto");
                        info = Console.ReadLine();
                        infoArray = info.Split(',');
                        trimString(infoArray);
                        payment = new Payment(infoArray, credit.CreditId, credit.UserId);
                        resp = paymentController.Post(payment);
                        var payRespCont = resp as OkNegotiatedContentResult<string>;
                        if (payRespCont != null)
                        {
                            Console.WriteLine(payRespCont.Content);
                        }
                        else
                        {
                            var errorMsg = resp as NegotiatedContentResult<string>;
                            Console.WriteLine(errorMsg.Content);
                        }
                        break;

                    case "6":
                        continuar = false;
                        break;
                }
            }
        }
    }
}
