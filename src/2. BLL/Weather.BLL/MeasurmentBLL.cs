using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Weather.BLL.ApiModels.In;
using Weather.BLL.ApiModels.Out;
using Weather.DAL.Context;
using Weather.DAL.Models;

namespace Weather.BLL
{
    public class MeasurmentBLL
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger _log;

        public MeasurmentBLL(AppDbContext db, IMapper mapper, ILogger log)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _log = log ?? throw new ArgumentNullException(nameof(log));
        }

        public async Task<IEnumerable<MeasurmentViewModel>> GetAsync(Guid deviceId)
        {
            var measurments = await _db.Measurements.Where(measurment => measurment.DeviceId == deviceId).Select(measurment => _mapper.Map<MeasurmentViewModel>(measurment)).ToListAsync();
            
            return measurments;
        }

        public async Task<bool> SaveAsync(MeasurmentBindingModel measurmentBinding)
        {
            bool result = true;

            try
            {
                var measurment = await _db.Measurements.FirstOrDefaultAsync(m => m.Id == measurmentBinding.Id);

                if (measurment == null)
                {
                    measurment = new Measurement();
                    _db.Measurements.Add(measurment);
                }

                measurment.DateTime = measurmentBinding.DateTime;
                measurment.DeviceId = measurmentBinding.DeviceId;
                measurment.Unite = measurmentBinding.Unite;
                measurment.Value = measurment.Value;

                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _log.Error(ex, "MeasurmentBLL: Error occure during saving.");
                result = false;
            }

            return result;
        }
    }
}
