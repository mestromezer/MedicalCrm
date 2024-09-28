// Для DbException
using MedicalCrmLib.Interfaces;
using MedicalCrmLib.Model;
using Microsoft.EntityFrameworkCore;

namespace MedicalCrmLib.Repositories
{
    public class CleaningScheduleRepository(CrmDbContext context)
        : IRepository<CleaningSchedule, (int RoomNumber, DateTime CleaningDate)>
    {
        public async Task<List<CleaningSchedule>> GetAsList()
        {
            return await context.CleaningSchedules.ToListAsync();
        }

        public async Task<List<CleaningSchedule>> GetAsList(Func<CleaningSchedule, bool> predicate)
        {
            return await Task.Run(() => context.CleaningSchedules.AsEnumerable().Where(predicate).ToList());
        }

        public async Task Add(CleaningSchedule newRecord)
        {
            try
            {
                await context.CleaningSchedules.AddAsync(newRecord);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException ex) 
            {
                throw new Exception("Ошибка при добавлении записи: " + ex.InnerException?.Message);
            }
        }

        public async Task Delete((int RoomNumber, DateTime CleaningDate) key)
        {
            var cleaningSchedule = await context.CleaningSchedules
                .FindAsync(key.RoomNumber, key.CleaningDate);

            if (cleaningSchedule != null)
            {
                try
                {
                    context.CleaningSchedules.Remove(cleaningSchedule);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    throw new Exception("Ошибка при удалении записи: " + ex.InnerException?.Message);
                }
            }
        }

        public async Task Update(CleaningSchedule newValue)
        {
            try
            {
                context.CleaningSchedules.Update(newValue);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Ошибка при обновлении записи: " + ex.InnerException?.Message);
            }
        }
    }
}
