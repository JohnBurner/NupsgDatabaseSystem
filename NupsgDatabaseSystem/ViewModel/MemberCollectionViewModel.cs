using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using NupsgDatabaseSystem.Service;
using NupsgDatabaseSystem.View;
using BurnerMVVM;
using NupsgDatabaseSystem.Model;

namespace NupsgDatabaseSystem.ViewModel
{
    public class MemberCollectionViewModel:ViewModelBase
    {
        //Fields
        IMemberService _memberService;

        //Ctor
        public MemberCollectionViewModel(IMemberService memberService)
        {
            _memberService = memberService;
           MemberDetailsCommand = new RelayCommand(OnMemberDetails);
           AddMemberCommand = new RelayCommand(OnAddMember);
           EditMemberCommand = new RelayCommand(OnEditMember);
           ClearSearchCommand = new RelayCommand(OnClearSearch);
            SearchCommand = new RelayCommand(OnSearch);

           Members = new ObservableCollection<Member>(_memberService.GetAllMembers());
        }

        //Properties
        #region MyRegion
         
        public ObservableCollection<Member> Members { get; private set; }

        private Member _selectedMember;
        public Member SelectedMember 
        {
            get { return _selectedMember; }
            set { SetProperty(ref _selectedMember, value); }
        }
        private string _searchString;
        public string SearchString
        {
            get { return _searchString; }
            set { SetProperty(ref _searchString, value); }
        }

        #endregion

        //Commands
        #region Commands
        public ICommand MemberDetailsCommand { get; private set; }
        public ICommand EditMemberCommand{ get; private set; }
        public ICommand AddMemberCommand { get; private set; }
        public ICommand ClearSearchCommand { get; private set; }
        public ICommand SearchCommand { get; private set; }
        #endregion

        //events
        #region events
        public event Action<int> MemberDetailsRequested = delegate { };
        public event Action<Member> AddMemberRequested = delegate { };
        public event Action<int> EditMemberRequested = delegate { };
        #endregion

        //Methods
        #region Methods
        private void OnMemberDetails()
        {
            MemberDetailsRequested(_selectedMember.MemberId);
        }
        private void OnAddMember()
        {
            AddMemberRequested(new Member());
        }
        private void OnEditMember()
        {
            EditMemberRequested(_selectedMember.MemberId);
        }
        private void OnClearSearch()
        {
            SearchString = String.Empty;
        }
        private void OnSearch()
        {
            throw  new NotImplementedException();
        }

        #endregion

        

        
    }
}
