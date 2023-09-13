﻿using Microsoft.EntityFrameworkCore;
using Proj_Ecorush.Models;
using Proj_Ecorush.Services.Interfaces;

namespace Proj_Ecorush.Services.Services
{
    public class AfforestationServices : IAfforestation
    {
        public EcoRushDbContext? _context;

        public AfforestationServices(EcoRushDbContext? context)
        {
            _context = context;
        }
        public async Task<string> AddNewActivityAF(Afforestation afforestation)
        {
            _context.Afforestations.Add(afforestation);
            await _context.SaveChangesAsync();

            return "Activity successfully saved";
        }

        public async Task<List<Afforestation>> GetAFbyStatus(string status)
        {
            List<Afforestation> afforestations = await _context.Afforestations.ToListAsync();
            afforestations = afforestations.Where(wc => wc.Status == status).ToList();

            if (afforestations == null)
            {
                throw new Exception();
            }

            return afforestations;
        }

        public async Task<List<Afforestation>> GetAllActivitiesAF()
        {

            List<Afforestation> afforestations = await _context.Afforestations.ToListAsync();
            return afforestations;
        }

        public async Task<List<Afforestation>> GetAFbyEmail(string email)
        {
            List<Afforestation> afforestations = await _context.Afforestations.ToListAsync();
            afforestations = afforestations.Where(wc => wc.EmailId == email).ToList();

            if (afforestations == null)
            {
                throw new Exception();
            }

            return afforestations;
        }

        public async Task<string> UpdateActivityAF(int activityID, Afforestation afforestation)
        {
            var afforestation1 = await _context.Afforestations.FindAsync(activityID);



            if (afforestation1 == null)
            {
                throw new Exception();
            }
            else
            {
                afforestation1.Evidence = afforestation.Evidence;
                afforestation1.PlantaionLoc = afforestation.PlantaionLoc;
                afforestation1.ActivityDate = afforestation.ActivityDate;
                afforestation1.Ccawarded = afforestation.Ccawarded;
                afforestation1.Status = afforestation.Status;
                await _context.SaveChangesAsync();

                return "Update was successfull";
            }
        }
    }
}
