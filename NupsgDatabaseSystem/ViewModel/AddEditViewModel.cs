using BurnerMVVM;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using NupsgDatabaseSystem.Model;
using NupsgDatabaseSystem.Service;

namespace NupsgDatabaseSystem.ViewModel
{
    public class AddEditViewModel:ViewModelBase
    {
        private IMemberService _service;
        public AddEditViewModel(IMemberService service)
        {
            _service = service;
            SaveCommand = new RelayCommand(onSaveMember);
            UpdateCommand = new RelayCommand(onUpdateMember);
            CancelCommand = new RelayCommand(onCancel);
            CellList = _service.GetCellList();
            CourseList = _service.GetCourseList();
        }

        #region Methods
        private void onSaveMember()
        {

        }
        private void onUpdateMember()
        {

        }
        private void onCancel()
        {
            MemberCollectionRequested();
        }
        private void SetOtherFields()
        {
            
        }
        #endregion

        #region Events
        public event Action MemberCollectionRequested = delegate { }; 
        #endregion

        #region Properties
        private bool _editMode;
        public bool EditMode
        {
            get { return _editMode; }
            set { SetProperty(ref _editMode, value); }
        }

        private int _memberId;
        public int MemberId
        {
            get { return _memberId; }
            set
            {
                SetProperty(ref _memberId, value);
                Member = _service.GetMember(_memberId);
                SetOtherFields();
            }
        }

        private Member _member;
        public Member Member
        {
            get { return _member; }
            set { SetProperty(ref _member, value); }
        }

        private Residence _residence;
        public Residence Residence
        {
            get { return _residence; }
            set { SetProperty(ref _residence, value); }
        }

        private Contact _contact;
        public Contact Contact
        {
            get { return _contact; }
            set { SetProperty(ref _contact, value); }
        }

        private Cell _cell;
        public Cell Cell
        {
            get { return _cell; }
            set { SetProperty(ref _cell, value); }
        }

        public List<string> CellList { get; set; }
        public List<string> CourseList { get; set; }
        #endregion

        #region Commands
        public ICommand SaveCommand { get; private set; }
        public ICommand UpdateCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }
        #endregion

    }
}
