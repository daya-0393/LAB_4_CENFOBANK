using Entities_POJO;
using CoreAPI;
using WebAPI;
using Exceptions;
using System;
using System.Collections.Generic;
using WebAPI.Controllers;
using System.Web.Http;
using System.Web.Http.Results;
using System.Threading;

namespace Testing
{
    class Program
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


        static void Main(string[] args)
        {

            runProgram();

        }

        public static void runProgram() {

            var continuar = true;
            while (continuar)
            {
                try
                {
                    Random rand = new Random();
                    Customer customer = new Customer();
                    Address address = new Address();
                    var customerCont = new CustomerController();
                    var addressCont = new AddressController();
                    IHttpActionResult resp;


                    Console.WriteLine("\n Bienvenido a CENFOBANK \n");
                    Console.WriteLine("Que desea realizar?");
                    Console.WriteLine("1.Registrar un nuevo cliente");
                    Console.WriteLine("2.Buscar cliente");
                    Console.WriteLine("3.Listar todos los clientes");
                    Console.WriteLine("4.Salir");
                    Console.WriteLine("Digite la opcion deseada: ");
                    var option = Console.ReadLine();
                    //MENU GENERAL
                    switch (option)
                    {
                        case "1":

                            string userInfo;
                            string[] userArray;

                            Console.WriteLine("***************************");
                            Console.WriteLine("----- REGISTRAR CLIENTE -----");
                            Console.WriteLine("***************************");
                            Console.WriteLine("Digite numero de cedula, nombre, apellido, fecha de nacimiento, edad, estado civil, genero");
                            userInfo = Console.ReadLine();
                            Console.WriteLine("Ingrese la direccion en el siguiente orden: Provincia, Canton, Distrito. ***CON TILDES");
                            var addressInput = Console.ReadLine();

                            addressInput = addressInput.ToUpper();
                            userArray = userInfo.Split(',');
                            var addressArray = addressInput.Split(',');
                            trimString(userArray);
                            trimString(addressArray);

                            address = new Address(addressArray);
                            //retorna el id de la direccion ingresada
                            resp = addressCont.Get(address);
                            var addressId = resp as OkNegotiatedContentResult<int>;
                            //resgistra el cliente con el id de la direccion proporcionada
                            if(addressId == null)
                            {
                                Console.WriteLine("La direccion ingresada no existe");
                            }
                            else
                            {
                                customer = new Customer(userArray, addressId.Content);
                                resp = customerCont.Post(customer);
                                var creRespCont = resp as OkNegotiatedContentResult<string>;

                                if(creRespCont != null)
                                {
                                    Console.WriteLine(creRespCont.Content);
                                }
                                else
                                {
                                    var errorMsg = resp as NegotiatedContentResult<string> ;
                                    Console.WriteLine(errorMsg.Content);
                                }
                            }
                            break;

                        case "2":

                            Console.WriteLine("***************************");
                            Console.WriteLine("----- BUSCAR CLIENTE -----");
                            Console.WriteLine("***************************");
                            Console.WriteLine("Digite el numero de cedula del usuario:");

                            string customerId = Console.ReadLine();
                            resp = customerCont.Get(customerId);
                            var contentResult = resp as OkNegotiatedContentResult<Customer>;
                            customer = contentResult.Content;

                            if (customer != null)
                            {
                                Console.WriteLine(" ==> CLIENTE: " + customer.GetEntityInformation());
                                Console.WriteLine("*** Gestionar cliente ***");
                                Console.WriteLine("1. Cuentas bancarias del usuario");
                                Console.WriteLine("2. Operaciones de creditos del usuario");
                                Console.WriteLine("3. Modificar perfil del usuario");
                                Console.WriteLine("4. Eliminar usuario");
                                Console.Write("Digite la opcion deseada: ");
                                option = Console.ReadLine();
                                //MENU DE USUARIO
                                switch (option)
                                {
                                    case "1":
                                        AccountMenu.ControlAccounts(customer.Id);
                                        break;

                                    case "2":
                                        CreditMenu.ControlCredits(customer.Id);
                                        break;

                                    case "3":
                                        Console.WriteLine("\n Ingrese la informacion actualizada");
                                        Console.Write("Nombre: ");
                                        customer.Name = Console.ReadLine();
                                        Console.Write("Apellido: ");
                                        customer.LastName = Console.ReadLine();
                                        Console.Write("Fecha de nacimiento en el siguiente formato (aaaa-mm-dd): ");
                                        customer.BirthDate = Convert.ToDateTime(Console.ReadLine());
                                        Console.Write("Edad: ");
                                        customer.Age = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("Estado civil: ");
                                        customer.CivilStatus = Convert.ToChar(Console.ReadLine());
                                        Console.WriteLine("Genero: ");
                                        customer.Gender = Convert.ToChar(Console.ReadLine());
                                        resp = customerCont.Put(customer);
                                        var updRespCont = resp as OkNegotiatedContentResult<string>;

                                        if (updRespCont != null)
                                        {
                                            Console.WriteLine(updRespCont.Content);
                                        }
                                        else
                                        {
                                            var erroMsg = resp as NegotiatedContentResult<string>;
                                            Console.WriteLine(erroMsg.Content);
                                        }
                                        break;

                                    case "4":
                                        resp = customerCont.Delete(customer);
                                        var delRespCont = resp as OkNegotiatedContentResult<string>;

                                        if (delRespCont != null)
                                        {
                                            Console.WriteLine(delRespCont.Content);
                                        }
                                        else
                                        {
                                            var erroMsg = resp as NegotiatedContentResult<string>;
                                            Console.WriteLine(erroMsg.Content);
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                throw new Exception("El usuario no esta registrado");
                            }

                            break;

                        case "3":

                            Console.WriteLine("***************************");
                            Console.WriteLine("----- LISTAR CLIENTES -----");
                            Console.WriteLine("***************************");

                            resp = customerCont.Get();
                            var contentResp = resp as OkNegotiatedContentResult<List<Customer>>;
                            var lstCustomers = contentResp.Content;
                            Console.WriteLine(lstCustomers);
                            var count = 0;

                            foreach (var c in lstCustomers)
                            {
                                count++;
                                Console.WriteLine(count + " ==> " + c.GetEntityInformation());
                            }

                            break;

                        case "4":
                            continuar = false;
                            break;
                    }
                }
                catch (BussinessException bex)
                {
                    Console.WriteLine("***************************");
                    Console.WriteLine("ERROR: \n");
                    Console.WriteLine(bex.AppMessage.Message);
                    Console.WriteLine("***************************");
                }
            }

            Console.ReadLine();
        }
    }
}
