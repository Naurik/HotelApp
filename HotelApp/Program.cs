using Hotel.DataAccess;
using Hotel.Services;
using System;
using System.Text.RegularExpressions;

namespace HotelApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region AddToDB
            string[] hotelName = { "Hilton Garden Inn", "RIXOS", "Radisson Park Inn", "Mariott" };
            //#region AddHotel
            //using (AddHotel addHotel = new AddHotel())
            //{
            //    for (int i = 0; i < hotelName.Length; i++)
            //    {
            //        Hotels hotel = new Hotels() { Name = hotelName[i] };
            //        addHotel.SaveHotel(hotel);
            //    }
            //}
            //#endregion

            //#region AddRoom
            //using (AddRoom addRoom = new AddRoom())
            //{
            //    Random rnd = new Random();
            //    for (int i = 0; i < 15; i++)
            //    {
            //        //Console.WriteLine("Введите дату брони с - /г/м/д");
            //        //int YearBegin = int.Parse(Console.ReadLine());
            //        //int MonthBegin = int.Parse(Console.ReadLine());
            //        //int DayBegin = int.Parse(Console.ReadLine());
            //        //Console.WriteLine("Введите дату брони до - /г/м/д");
            //        //int YearEnd = int.Parse(Console.ReadLine());
            //        //int MonthEnd = int.Parse(Console.ReadLine());
            //        //int DayEnd = int.Parse(Console.ReadLine());
            //        Room room = new Room()
            //        {
            //            RoomNumber = rnd.Next(1, 200),
            //            HotelId = rnd.Next(1, 4),
            //            BeginReserve = new DateTime(rnd.Next(2001,2002), rnd.Next(01, 12), rnd.Next(1, 30)),
            //            EndReserve = new DateTime(rnd.Next(2003, 2004), rnd.Next(01, 12), rnd.Next(1, 30))
            //        };
            //        addRoom.SaveRoom(room);
            //    }
            //}
            //#endregion
            #endregion

            using (AddRoom getHotelRoom = new AddRoom())
            {
                #region ChoiceHotel
                Console.WriteLine("Выберите отель:");
                Console.WriteLine("1.Hilton Garden Inn\n2.RIXOS\n3.Radisson Park Inn\n4.Mariott");
                int numberId = int.Parse(Console.ReadLine());
                Console.WriteLine("Выберите дату с-- г/м/д");
                int year1 = int.Parse(Console.ReadLine());
                int month1 = int.Parse(Console.ReadLine());
                int day1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Выберите дату до-- г/м/д");
                int year2 = int.Parse(Console.ReadLine());
                int month2 = int.Parse(Console.ReadLine());
                int day2 = int.Parse(Console.ReadLine());
                Console.WriteLine("Выберите номер комнаты:");
                int numberRoom = int.Parse(Console.ReadLine());
                DateTime reserveDateBegin = new DateTime(year1, month1, day1);
                DateTime reserveDateEnd = new DateTime(year2, month2, day2);
                var result = getHotelRoom.GetRoomById(numberId, reserveDateBegin, reserveDateEnd, numberRoom);
                Room addroom = new Room()
                {
                    RoomNumber = numberRoom,
                    HotelId = numberId,
                    BeginReserve = reserveDateBegin,
                    EndReserve = reserveDateEnd
                };
                #endregion
                Console.WriteLine("1-Зарегестрироваться?\n2-Войти\n3-Выйти?");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        #region Registration
                        using (AddUser addUser = new AddUser())
                        {
                            Users user = new Users();


                            Console.WriteLine("Введите логин пользователя: ");
                            string login = Console.ReadLine();
                            Users user1 = new Users();
                            user1.Login = login;
                            var result1 = addUser.GetUserByLog(login);
                            while (result1 != null)
                            {
                                Console.WriteLine("Login already exits! Try again//Press Enter");
                                Console.ReadLine();
                                login = Console.ReadLine();
                            }
                            



                            Console.WriteLine("Введите пароль пользователя: ");
                            #region Password
                            bool repeat = true;
                            string password = "";
                            Regex reg = new Regex(@"(?=^.{6,32}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$");
                            ConsoleKeyInfo info = Console.ReadKey(true);
                            while (repeat)
                            {
                                while (info.Key != ConsoleKey.Enter)
                                {
                                    if (info.Key != ConsoleKey.Backspace)
                                    {
                                        Console.Write("*");
                                        password += info.KeyChar;
                                    }
                                    else if (info.Key == ConsoleKey.Backspace)
                                    {
                                        if (!string.IsNullOrEmpty(password))
                                        {
                                            password = password.Substring(0, password.Length - 1);
                                            int pos = Console.CursorLeft;
                                            Console.SetCursorPosition(pos - 1, Console.CursorTop);
                                            Console.Write(" ");
                                            Console.SetCursorPosition(pos - 1, Console.CursorTop);
                                        }
                                    }
                                    info = Console.ReadKey(true);
                                }
                                if (reg.IsMatch(password))
                                {
                                    repeat = false;
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Введите пароль заново!");
                                    password = "";
                                    info = Console.ReadKey(true);
                                }
                            }
                            #endregion


                            Console.WriteLine();
                            Console.WriteLine("Введите павторный пароль пользователя: ");
                            #region RepeatPassword
                            bool repeat1 = true;
                            string repeatPassword = "";
                            ConsoleKeyInfo info1 = Console.ReadKey(true);
                            while (repeat1)
                            {
                                while (info1.Key != ConsoleKey.Enter)
                                {
                                    if (info1.Key != ConsoleKey.Backspace)
                                    {
                                        Console.Write("*");
                                        repeatPassword += info1.KeyChar;
                                    }
                                    else if (info1.Key == ConsoleKey.Backspace)
                                    {
                                        if (!string.IsNullOrEmpty(repeatPassword))
                                        {
                                            repeatPassword = repeatPassword.Substring(0, repeatPassword.Length - 1);
                                            int pos = Console.CursorLeft;
                                            Console.SetCursorPosition(pos - 1, Console.CursorTop);
                                            Console.Write(" ");
                                            Console.SetCursorPosition(pos - 1, Console.CursorTop);
                                        }
                                    }
                                    info1 = Console.ReadKey(true);
                                }
                                if (string.Equals(repeatPassword, password))
                                {
                                    repeat1 = false;
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Пароли не совпадают! Введите снова!");
                                    repeatPassword = "";
                                    info1 = Console.ReadKey(true);
                                }
                            }
                            #endregion


                            Console.WriteLine();
                            Console.WriteLine("Введите email пользователя: ");
                            #region Email
                            string email = Console.ReadLine();
                            bool repeat2 = true;
                            Regex trueEmail = new Regex(@"^[-\w.]+@([A-z0-9][-A-z0-9]+\.)+[A-z]{2,4}$");
                            while (repeat2)
                            {
                                if (trueEmail.IsMatch(email))
                                {
                                    repeat2 = false;
                                }
                                else
                                {
                                    Console.WriteLine("Введите email заново!");
                                    email = Console.ReadLine();
                                }
                            }
                            #endregion


                            Console.WriteLine("Введите номер пользователя: ");
                            #region PhoneNumber
                            string phoneNumber = Console.ReadLine();
                            Regex truePhoneNumber = new Regex(@"^\+?[7]\d{10}$");
                            bool repeat3 = true;
                            while (repeat3)
                            {
                                if (truePhoneNumber.IsMatch(phoneNumber))
                                {
                                    repeat3 = false;
                                }
                                else
                                {
                                    Console.WriteLine("Введите номер заново!");
                                    phoneNumber = Console.ReadLine();
                                }

                            }
                            #endregion

                            user.SendSmsTwilio(phoneNumber);

                            #region Sms
                            Console.WriteLine("Введите смс: ");
                            string code = Console.ReadLine();
                            bool repeat4 = true;
                            while (repeat4)
                            {
                                if (string.Equals(user.Sms, code))
                                {
                                    repeat4 = false;
                                }
                                else
                                {
                                    Console.WriteLine("Неправильный код. Введите заново");
                                    code = Console.ReadLine();
                                }

                            }
                            #endregion


                            Users users = new Users()
                            {
                                Login = login,
                                Email = email,
                                PhoneNumber = phoneNumber
                            };

                            addUser.SavePerson(users);
                            Console.WriteLine("Вы успешно зарегестрированы!");
                            
                        }
                        #endregion
                         break;
                    case 2:
                        #region SignIn
                        using (AddUser addUser1 = new AddUser())
                        {
                            Console.WriteLine("Введите логин пользователя: ");
                            string login = Console.ReadLine();
                            Users user = new Users();
                            user.Login = login;
                            var result2 = addUser1.GetUserByLog(login);
                            while (result2 == null)
                            {
                                Console.WriteLine("Login already exits! Try again//Press Enter");
                                Console.ReadLine();
                                login = Console.ReadLine();
                            }
                            Console.WriteLine("Вход успешно выполнен");
                            Console.ReadLine();
                        }
                        #endregion
                        break;
                    case 3: break;

                }
                if (choice != 3)
                {
                    getHotelRoom.SaveRoom(addroom);
                    Console.WriteLine($"HotelID = {result.HotelId}\nRoomNumber = {result.RoomNumber}");
                }

                Console.ReadLine();

               
            }

            

           

        }
    }
}
