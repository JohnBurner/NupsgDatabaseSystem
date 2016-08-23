using BurnerMVVM;
using NupsgDatabaseSystem.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using NupsgDatabaseSystem.Model;

namespace NupsgDatabaseSystem.ViewModel
{
    public class MemberDetailsViewModel:ViewModelBase
    {
        IMemberService _service;
        public MemberDetailsViewModel(IMemberService service)
        {
            _service = service;
            
           PrintCommand = new RelayCommand<Grid>(Print);
        }

        private void SetOtherFields()
        {
            
        }

        //Fields
           #region fields
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
            get { return _residence;}
            set { SetProperty(ref _residence, value); }
        }

        private Contact _contact;
        public Contact Contact
        {
            get { return _contact; }
            set { SetProperty(ref _contact, value); }
        }
        #endregion


        //Commands
        #region Commands
        public ICommand PrintCommand { get; private set; }
        private void Print(Grid myVisual)
        {
            if (myVisual != null)
            {
                PrintDialog printDlg = new System.Windows.Controls.PrintDialog();
                if (printDlg.ShowDialog() == true)
                {
                    printDlg.PrintVisual(myVisual, "www.Kleitech.com");
                } 
            }
        } 
        #endregion
        


    }
}
