using Mexican_Lottery_dotnet_API.Data;
using Mexican_Lottery_dotnet_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Mexican_Lottery_dotnet_API.Services
{
    public class LotteryService
    {
        private readonly DataContext _context;

        public LotteryService(DataContext context)
        {
            _context = context;
        }

        async public Task<List<Card>> GetCards()
        {
            return await _context.Cards.ToListAsync();
        }

        async public Task<List<Table>> GetTables()
        {
            return await _context.Tables.ToListAsync();
        }

        async public Task<List<Table>> GenerateRandomTables(int length)
        {
            try
            {
                List<Card> cards = await _context.Cards.ToListAsync();
                List<Table> tables = new List<Table>();
                for (int c = 0; c < length; c++)
                {
                    List<string> cardsForNewTable = new List<string>();
                    for (int t = 0; t < 16; t++)
                    {
                        Card randomCard = cards[new Random().Next(0, 54)];
                        if (cardsForNewTable.Contains(randomCard.Name))
                        {
                            t--;
                            continue;
                        }

                        cardsForNewTable.Add(randomCard.Name);
                    }

                    if (IsTableCloned(tables, cardsForNewTable))
                    {
                        c--;
                        continue;
                    }

                    tables.Add(new Table
                    {
                        Card1 = cardsForNewTable[0],
                        Card2 = cardsForNewTable[1],
                        Card3 = cardsForNewTable[2],
                        Card4 = cardsForNewTable[3],
                        Card5 = cardsForNewTable[4],
                        Card6 = cardsForNewTable[5],
                        Card7 = cardsForNewTable[6],
                        Card8 = cardsForNewTable[7],
                        Card9 = cardsForNewTable[8],
                        Card10 = cardsForNewTable[9],
                        Card11 = cardsForNewTable[10],
                        Card12 = cardsForNewTable[11],
                        Card13 = cardsForNewTable[12],
                        Card14 = cardsForNewTable[13],
                        Card15 = cardsForNewTable[14],
                        Card16 = cardsForNewTable[15]
                    }
                    );
                }

                tables.ForEach(table =>
                {
                    _context.Tables.Add(table);
                });

                await _context.SaveChangesAsync();

                return tables;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Table>();
            }
        }

        private bool IsTableCloned(List<Table> tables, List<string> newTable)
        {
            bool result = false;
            tables.ForEach(table =>
            {
                int coincidences = 0;
                foreach (PropertyInfo prop in table.GetType().GetProperties())
                {
                    var type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                    if (prop.GetValue(table, null) != null && newTable.Contains(prop.GetValue(table, null).ToString()))
                        coincidences++;

                }

                if (coincidences == 16)
                    result = true;
            });

            return result;
        }
    }
}
