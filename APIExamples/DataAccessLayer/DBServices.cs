using APIExamples.Models;
using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using System.Threading.Tasks;

namespace APIExamples.DataAccessLayer
{
    public class DBServices
    {
        private static string connectionString = Path.Combine(Directory.GetCurrentDirectory(), "storeDB.sqlite");

        public string GetScope(int id)
        {
            using(SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                return connection.Table<User>().Where(u => u.Id == id).Select(s => s.Scope).Single();
            }
        }
        public static User GetUser(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                return connection.Table<User>().Where(u => u.Id.Equals(id)).FirstOrDefault();
            }
        }

        public static List<User> GetUsers()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                return connection.Table<User>().ToList();
            }
        }

        public static bool AddUser(User user)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    int row = connection.Insert(user);
                    if (row > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static bool UpdateUser(User user)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    int row = connection.Update(user);
                    if (row > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static bool DeleteUser(User user)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    int row = connection.Delete(user);
                    if (row > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        //Order Table
        public static Order GetOrder(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                return connection.Table<Order>().Where(o => o.Id.Equals(id)).FirstOrDefault();
            }
        }

        public static List<Order> GetOrders()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                return connection.Table<Order>().ToList();
            }
        }

        public static bool AddOrder(Order order)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    int row = connection.Insert(order);

                    if (row > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static bool UpdateOrder(Order order)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    int row = connection.Update(order);

                    if (row > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static bool DeleteOrder(int Id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    int row = conn.Delete<Order>(Id);
                    if (row > 0) return true;
                    else return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        //User Table
        public static Item GetItem(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                return conn.Table<Item>().Where(i => i.Id.Equals(id)).FirstOrDefault();
            }
        }

        public static List<Item> GetItems()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                return conn.Table<Item>().ToList();
            }
        }

        public static bool AddItem(Item item)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    int row = conn.Insert(item);
                    if (row > 0) return true;
                    else return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static bool UpdateItem(Item item)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    int row = conn.Update(item);
                    if (row > 0) return true;
                    else return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static bool DeleteItem(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    int row = conn.Delete<Item>(id);
                    if (row > 0) return true;
                    else return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }

}
