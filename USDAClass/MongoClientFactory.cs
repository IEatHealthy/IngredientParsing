using System;
using MongoDB.Driver;
using MongoDB.Bson;

namespace USDAClass
{
    //singleton for MongoDB Connection
    //should use IoC container in the future
    //this class is NOT THREAD SAFE
    public class MongoClientFactory
    {
        private static MongoClient _instance = null;

        private static object syncLock = new object();
        private const string CONNECT_STRING = "<INSERT CONNECT STRING HERE>";

        protected MongoClientFactory(){}

        public static MongoClient GetInstance(){
            
            //do not use double-checked locking!
            lock(syncLock){
                if (_instance == null)
                {
                    _instance = new MongoClient(CONNECT_STRING);
                    var db = _instance.GetDatabase("food-data");
                    bool isMongoLive = db.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait(10000);

                    if (isMongoLive)
                    {
                        Console.WriteLine("Successfully connected to mongo cluster: " + _instance.Cluster.ClusterId.Value);
                        Console.WriteLine("Cluster Type " + _instance.Cluster.Description.State.ToString());
                    }
                    else
                    {
                        Console.WriteLine("Error: could not connect to database");
                        _instance = null;
                    }

                }
            }

            return _instance;
        }
    }
}
