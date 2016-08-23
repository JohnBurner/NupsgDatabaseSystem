using System;
using System.Collections.Generic;
using System.Linq;
using NupsgDatabaseSystem.Model;
using System.Data.SqlServerCe;
using System.Data;

namespace NupsgDatabaseSystem.Service
{
    public class MemberService:IMemberService
    {
        
        public void AddMember(Member newMember)
        {
            throw new NotImplementedException();
        }

        public List<Member> GetAllMembers()
        {
            List<Member> Members = new List<Member>();
            Connection con = new Connection();
            //con.connectionOpen();
            // Query string
            string strSQL = "SELECT * FROM Customers";
            SqlCeCommand mySqlCommand = con.cmd();
            mySqlCommand.CommandText = strSQL;
            SqlCeDataAdapter _DataAdapterCustomer = new SqlCeDataAdapter();
            _DataAdapterCustomer.SelectCommand = mySqlCommand;
            con.connectionClose();
            DataSet _DataSet = new DataSet();
            // Fill DataSet
            _DataAdapterCustomer.Fill(_DataSet, "Customers");
            // Load Data from the DataSet into the ListView
            // Get the table from the data set
            DataTable dtable = _DataSet.Tables["Customers"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                DataRow drow = dtable.Rows[i];
                // Only row that have not been deleted
                if (drow.RowState != DataRowState.Deleted)
                {
                    Member newMember = new Member();
                    newMember.MemberId = Convert.ToInt32(drow["MemberId"]);
                    newMember.LastName = drow["LastName"].ToString();
                    newMember.FirstName = drow["FirstName"].ToString();
                    newMember.Sex = drow["Sex"].ToString();
                    newMember.DateOfBirth = DateTime.Parse(drow["DateOfBirth"].ToString());
                    newMember.IndexNumber = drow["IndexNumber"].ToString();
                    newMember.DateOfAdmission = DateTime.Parse(drow["DateOfAdmssion"].ToString());
                    newMember.CourseId =Convert.ToInt32( drow["CourseId"]);
                    newMember.CellId =Convert.ToInt32(drow["CellId"]);
                    // Add the list items to the Members Collection.
                    Members.Add(newMember);
                }
            }
            return Members;
        }

        public void UpdateMember(Member updatedMember)
        {
            throw new NotImplementedException();
        }

        public void DeleteMember(Member member)
        {
            throw new NotImplementedException();
        }

        public Member GetMember(int memberId) 
        {
            throw new NotImplementedException();
        }

        public List<string> GetCellList()
        {
            throw new NotImplementedException();
        }

        public List<string> GetCourseList()
        {
            throw new NotImplementedException();
        }
    }
}
