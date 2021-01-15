using DBLibrary.DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBlibrary.BuisnessLogic
{
    public class ProcesorLikes
    {
        public static short LoadLikes(int PID)
        {
            Vote voutes = new Vote()
            {
                
                PID = PID
            };
            string sql = @"Select sum(VAL) AS VAL
                            from 
	                            dbo.Voutes  
                            where 
	                            PID like @PID;";
            var ret = SqlDataAccess.getdata<Vote>(sql, voutes);
            short val = ret[0].VAL;
            return val;
        }
        public static int AddVoute(int PID, int UID, short voute)
        {
            Vote data = new Vote()
            {
                VAL = voute,
                PID = PID,
                UID = UID

            };

            string sql = @"insert into dbo.Voutes (UID, PID, VAL) VALUES (@UID, @PID, @VAL);";
            int c = SqlDataAccess.SaveData(sql, data);
            return c;
        }
        public static int RemoveVoute(int PID, int UID)
        {
            Vote data = new Vote()
            {
                PID = PID,
                UID = UID

            };

            string sql = @"DELETE FROM dbo.Voutes WHERE UID = @UID and PID = @PID;";
            int c = SqlDataAccess.SaveData<Vote>(sql, data);
            return c;
        }
    }
}
