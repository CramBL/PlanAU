﻿using System;
using System.Collections.Generic;
using System.Text;
using Desktop_Application.DataAccessLayer;
using Desktop_Application.Models;
using Desktop_Application.ViewModels;
using DesktopApplication.Models;
using DryIoc.Messages;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;

namespace DesktopApplication.Test.Unit.ViewModelUnitTests
{
    class LoginViewModelUnitsTests
    {
        private LoginViewModel _uut;

        string validUserName = "AU999999";
        string validPassword = "123456";

        private string invalidUsername = "forkertBrugernavn";
        private string invalidPassword = "forkertKodeord";

        private IInputValidator _inputValidator;
        private IDAL_Student _dalStudent;
        private IMessageBox _messageBox;

        [SetUp]
        public void Setup()
        {
            
            _uut = new LoginViewModel();


            //substitute dependencies
            _uut.InputValidator = (_inputValidator = Substitute.For<IInputValidator>());
            _uut.DALStudent = (_dalStudent = Substitute.For<IDAL_Student>());
            _uut.MessageBox = (_messageBox = Substitute.For<IMessageBox>());

            //set test data
            _uut.UserNameBox = validUserName;
            _uut.PasswordBox = validPassword;
        }

        [Test]
        public void ExecuteLoginCommand_ValidLoginAttempt_ValidUsernameSyntax()
        {
            _uut.LoginCommand.Execute();

            _inputValidator.Received(1).ValidUsernameSyntax(validUserName);
        }

        [Test]
        public void ExecuteLoginCommand_ValidLoginAttempt_LoginAttemptAuthorize()
        {
            //arrange
            _inputValidator.ValidUsernameSyntax(validUserName).Returns(true);
            
            //act
            _uut.LoginCommand.Execute();

            //assert
            _dalStudent.ReceivedWithAnyArgs(1).LoginAttemptAuthorize(new Student());
        }

        [Test]
        public void ExecuteLoginCommand_InvalidUsernameLoginAttempt_ShowMessageInvalid()
        {
            //arrange
            _uut.InputValidator.ValidUsernameSyntax(invalidUsername).Returns(false);
            //act
            _uut.LoginCommand.Execute();
            //assert
            _messageBox.ReceivedWithAnyArgs(1).Show("");
        }

        [Test]
        public void ExecuteLoginCommand_InvalidPasswordLoginAttempt_ShowMessageInvalid()
        {
            //arrange
            _inputValidator.ValidUsernameSyntax(validUserName).Returns(true);
            _dalStudent.LoginAttemptAuthorize(new Student()).ReturnsNullForAnyArgs();
            //act
            _uut.LoginCommand.Execute();
            //assert
            _messageBox.ReceivedWithAnyArgs(1).Show("");
        }
    }
}