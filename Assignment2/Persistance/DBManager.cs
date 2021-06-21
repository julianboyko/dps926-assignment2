using System;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Assignment2.Models;
using SQLite;
using Xamarin.Forms;

namespace Assignment2.Persistance
{
    public class DBManager
    {
        private SQLiteAsyncConnection _connection;
        public DBManager()
        {
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        public async Task<ObservableCollection<FoodDataDB>> CreateTable() {
            await _connection.CreateTableAsync<FoodDataDB>();
            var foodDataFromDB = await _connection.Table<FoodDataDB>().ToListAsync();
            var allFoodData = new ObservableCollection<FoodDataDB>(foodDataFromDB);

            return allFoodData;
        }

        public void insertFoodData(FoodDataDB foodData)
        {
            _connection.InsertAsync(foodData);
        }

        public void deleteFoodData(FoodDataDB toDelete)
        {
            _connection.DeleteAsync(toDelete);
        }

    }
}
