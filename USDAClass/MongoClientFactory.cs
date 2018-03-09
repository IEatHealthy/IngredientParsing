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
        private const string CONNECT_STRING = "mongodb://IEatHealthy:j4fF4LoMPF1saw9w@ieathealthy-cluster0-shard-00-00-0q8tc.mongodb.net:27017,ieathealthy-cluster0-shard-00-01-0q8tc.mongodb.net:27017,ieathealthy-cluster0-shard-00-02-0q8tc.mongodb.net:27017/test?ssl=true&replicaSet=IEatHealthy-Cluster0-shard-0&authSource=admin";

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
