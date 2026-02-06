using MauiAppCoachV1.Core.Modele;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;



namespace MauiAppCoachV1.Core.Outils
{
    public class SQLiteDb
    {
    
            public const string DatabaseFilename = "dbcoach.db3";
            public static string DatabasePath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DatabaseFilename);
            public const SQLite.SQLiteOpenFlags Flags =

                SQLite.SQLiteOpenFlags.ReadWrite |

                SQLite.SQLiteOpenFlags.Create |

                SQLite.SQLiteOpenFlags.SharedCache;

            private SQLiteAsyncConnection connection;

            private async Task Initialize()
            {
                if (connection is not null)
                    return;

                connection = new(DatabasePath);
                await connection.CreateTableAsync<Profil>();


            }

            public async Task<int> SaveItemAsync(Profil unProfil)
            {
                await Initialize();
                if (unProfil.Id != 0)
                {
                    return await connection.UpdateAsync(unProfil);
                }
                else
                {
                    return await connection.InsertAsync(unProfil);
                }

            }

            public async Task<Profil> GetLastItemQueryAsync()
            {
                await Initialize();
                return await connection.FindWithQueryAsync<Profil>("SELECT * FROM Profil ORDER BY dateMesure DESC");

            }  
     
    }
}