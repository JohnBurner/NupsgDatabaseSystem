using System.Collections.Generic;
using NupsgDatabaseSystem.Model;

namespace NupsgDatabaseSystem.Service
{
    public interface IMemberService
    {
        void AddMember(Member newMember);
        List<Member> GetAllMembers();
        void UpdateMember(Member updatedMember);
        void DeleteMember(Member member);
        Member GetMember(int memberId);
        List<string> GetCellList();
        List<string> GetCourseList();
    }
}
