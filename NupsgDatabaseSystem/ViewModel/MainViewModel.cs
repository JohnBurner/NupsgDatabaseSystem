using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xaml;
using Microsoft.Practices.Unity;
using BurnerMVVM;
using NupsgDatabaseSystem.Model;

namespace NupsgDatabaseSystem.ViewModel
{
    public class MainViewModel:ViewModelBase
    {
        private MemberCollectionViewModel _memberCollectionViewModel;
        private MemberDetailsViewModel _memberDetailsViewModel;
        private AddEditViewModel _addEditViewModel;
        public MainViewModel()
        {
            _memberCollectionViewModel = ContainerHelper.Container.Resolve<MemberCollectionViewModel>();
            _memberDetailsViewModel = ContainerHelper.Container.Resolve<MemberDetailsViewModel>();
            
            CurrentViewModel = _memberCollectionViewModel;
            _memberCollectionViewModel.MemberDetailsRequested += NavToMemberDetails;
            _memberCollectionViewModel.EditMemberRequested += NavToMemberEdit;
            _memberCollectionViewModel.AddMemberRequested += NavToMemberAdd;

        }

        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel, value); }
        }

        //Methods
        #region methods

        private void NavToMemberDetails(int memberId)
        {
            _memberDetailsViewModel.MemberId = memberId;
            CurrentViewModel = _memberDetailsViewModel;
        }
        private void NavToMemberEdit(int memberId)
        {
            InitializeAddEditViewModel();
            _addEditViewModel.EditMode = true;
            _addEditViewModel.MemberId = memberId;
            CurrentViewModel = _addEditViewModel;
        }
        private void NavToMemberAdd(Member member)
        {
            InitializeAddEditViewModel();
            _addEditViewModel.EditMode = false;
            _addEditViewModel.Member = member;
            CurrentViewModel = _addEditViewModel;
        }

        private void InitializeAddEditViewModel()
        {
            _addEditViewModel = ContainerHelper.Container.Resolve<AddEditViewModel>();
            _addEditViewModel.MemberCollectionRequested += NavToMemberCollection;
        }

        private void NavToMemberCollection()
        {
            CurrentViewModel = _memberCollectionViewModel;
        }

        #endregion


    }
}
