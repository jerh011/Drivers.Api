using MongoDB.Driver;

using Drivers.Api.Models;
using Drivers.Api.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Bson;

namespace  Drivers.Api.Services;

  
        
public class CarrerasServices
{
    private readonly IMongoCollection<Carreras> _CarrerasCollection;
    public CarrerasServices( IOptions<DatabaseSettings> databaseSettings)
    {
        //Inicializar mi cliente de MongoDB 
        var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
       //Conectar a la base de datos MongoDB
        var mongoDB =
        mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
        _CarrerasCollection =
         mongoDB.GetCollection<Carreras>
            (databaseSettings.Value.Collections["Carreras"]);
    }
   
    public async Task<List<Carreras>> GetAsync() =>
    await _CarrerasCollection.Find(_ => true).ToListAsync();
   
    public async Task<Carreras> GetDriverById(string id)
    {
        return await _CarrerasCollection.FindAsync(new BsonDocument
    {{"_id",new ObjectId(id)}}).Result.FirstAsync();
    }

    public async Task InsertDriver(Carreras drivers)
    {
        await _CarrerasCollection.InsertOneAsync(drivers);
    }
    public async Task UpdateDriver(Carreras drivers)
    {
        var filter = Builders<Carreras>.Filter.Eq(S => S.Id, drivers.Id);
        await _CarrerasCollection.ReplaceOneAsync(filter, drivers);
    }

    public async Task DelateDriver(string id)
    {
        var filter = Builders<Carreras>.Filter.Eq(S => S.Id, id);
        await _CarrerasCollection.DeleteManyAsync(filter);
    }

}
        
