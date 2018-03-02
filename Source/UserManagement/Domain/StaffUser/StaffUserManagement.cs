using System;
using Concepts;
using doLittle.Domain;
using Domain.StaffUser.PhoneNumber;
using Domain.StaffUser.Add;
using Domain.StaffUser.Update;
using Events.StaffUser;

namespace Domain.StaffUser
{
    public class StaffUserManagement : AggregateRoot
    {
        public StaffUserManagement(Guid id) : base(id)
        {
        }

        #region VisibleCommands

        public void AddStaffUser(Add.BaseStaffUser command)
        {
            switch (command.Role)
            {
                case _Role.Admin:
                    AddAdmin(command);
                    break;
                case _Role.DataConsumer:
                    AddDataConsumer(command);
                    break;
                case _Role.DataCoordinator:
                    AddDataCoordinator(command);
                    break;
                case _Role.DataOwner:
                    AddDataOwner(command);
                    break;
                case _Role.DataVerifier:
                    AddDataVerifier(command);
                    break;
                case _Role.SystemCoordinator:
                    AddSystemCoordinator(command);
                    break;
            }

            // If the given role has mobilephonenumbers
            if (command.Role.RequiresExtensiveInfo())
            {
                AddPhoneNumbers(command);
            }
            // If the given role has AssignedNationalSocieties
            if (command.Role.RequiresAssignedNationalSocieties())
            {
                //TODO: Add/remove national societies. Implement a command and events similar to the phonenumbers
            }
        }

        public void UpdateStaffUser(UpdateStaffUser command)
        {
            switch (command.Role)
            {
                case _Role.Admin:
                    UpdateAdmin(command);
                    break;
                case _Role.DataConsumer:
                    UpdateDataConsumer(command);
                    break;
                case _Role.DataCoordinator:
                    UpdateDataCoordinator(command);
                    break;
                case _Role.DataOwner:
                    UpdateDataOwner(command);
                    break;
                case _Role.DataVerifier:
                    UpdateDataVerifier(command);
                    break;
                case _Role.SystemCoordinator:
                    UpdateSystemCoordinator(command);
                    break;
            }

            // If the given role has mobilephonenumbers
            if (command.Role.RequiresExtensiveInfo())
            {
                AddPhoneNumbers(command);
                RemovePhoneNumbers(command);
            }
            // If the given role has AssignedNationalSocieties
            if (command.Role.RequiresAssignedNationalSocieties())
            {
                //TODO: Add/remove national societies. Implement a command and events similar to the phonenumbers
            }
        }

        public void AddPhoneNumber(AddPhoneNumberToStaffUser command)
        {
            Apply(new PhoneNumberAddedToStaffUser(
                command.StaffUserId, command.PhoneNumber, 0
            ));
        }

        public void RemovePhoneNumber(RemovePhoneNumberFromStaffUser command)
        {
            Apply(new PhoneNumberRemovedFromStaffUser(
                command.StaffUserId, command.PhoneNumber, 0
            ));
        }

        #endregion

        #region PhoneNumber

        private void AddPhoneNumbers(Add.BaseStaffUser command)
        {
            // foreach (var number in command.MobilePhoneNumber)
            // {
            //     // Just handle the command directly, should be no point in giving it to the commandhandler(?)
            //     AddPhoneNumber(new AddPhoneNumberToStaffUser
            //     {
            //         PhoneNumber = number,
            //         Role = command.Role,
            //         StaffUserId = command.StaffUserId
            //     });
            // }
        }

        private void AddPhoneNumbers(UpdateStaffUser command)
        {
            foreach (var number in command.MobilePhoneNumbersAdded)
            {
                AddPhoneNumber(new AddPhoneNumberToStaffUser
                {
                    PhoneNumber = number,
                    Role = command.Role,
                    StaffUserId = command.StaffUserId
                });
            }
        }

        private void RemovePhoneNumbers(UpdateStaffUser command)
        {
            if (command.MobilePhoneNumbersRemoved != null && command.MobilePhoneNumbersRemoved.Count > 0)
            {
                foreach (var number in command.MobilePhoneNumbersRemoved)
                {
                    RemovePhoneNumber(new RemovePhoneNumberFromStaffUser
                    {
                        PhoneNumber = number,
                        Role = command.Role,
                        StaffUserId = command.StaffUserId
                    });
                }
            }
        }
        #endregion
        
        #region HandleAdd

        private void AddAdmin(Add.BaseStaffUser command)
        {
            // Apply(new AdminAdded(
            //     command.StaffUserId, command.FullName,
            //     command.DisplayName, command.Email
            //     ));

        }

        private void AddDataConsumer(Add.BaseStaffUser command)
        {
            // Apply(new DataConsumerAdded(
            //     command.StaffUserId, command.FullName,
            //     command.DisplayName, command.Email,
            //     command.Location.Longitude, command.Location.Latitude
            //     ));
        }
        private void AddDataCoordinator(Add.BaseStaffUser command)
        {
            // Apply(new DataCoordinatorAdded(
            //     command.StaffUserId, command.FullName, command.DisplayName,
            //     command.Email, command.YearOfBirth, (int)command.Sex, command.NationalSociety,
            //     (int)command.PreferredLanguage, command.Location.Longitude,
            //     command.Location.Latitude
            //     ));
        }
        private void AddDataOwner(Add.BaseStaffUser command)
        {
            // Apply(new DataOwnerAdded(
            //     command.StaffUserId, command.FullName, command.DisplayName,
            //     command.Email, command.YearOfBirth, (int)command.Sex, command.NationalSociety,
            //     (int)command.PreferredLanguage, command.Location.Longitude,
            //     command.Location.Latitude, command.Position, command.DutyStation
            //     ));
        }
        private void AddDataVerifier(Add.BaseStaffUser command)
        {
            // Apply(new DataVerifierAdded(
            //     command.StaffUserId, command.FullName, command.DisplayName,
            //     command.Email, command.YearOfBirth, (int)command.Sex, command.NationalSociety,
            //     (int)command.PreferredLanguage, command.Location.Longitude,
            //     command.Location.Latitude, DateTimeOffset.UtcNow
            //     ));
        }
        private void AddSystemCoordinator(Add.BaseStaffUser command)
        {
            // Apply(new SystemCoordinatorAdded(
            //     command.StaffUserId, command.FullName, command.DisplayName,
            //     command.Email, command.YearOfBirth, (int)command.Sex, command.NationalSociety,
            //     (int)command.PreferredLanguage, command.Location.Longitude,
            //     command.Location.Latitude
            //     ));
        }
        
        #endregion
        
        #region HandleUpdate

        private void UpdateAdmin(UpdateStaffUser command)
        {
            Apply(new AdminUpdated(
                command.StaffUserId, command.FullName, command.DisplayName,
                command.Email
            ));

        }

        private void UpdateDataConsumer(UpdateStaffUser command)
        {
            Apply(new DataConsumerUpdated(
                command.StaffUserId, command.FullName, command.DisplayName,
                command.Email, command.GpsLocation.Latitude, command.GpsLocation.Longitude
                ));
        }
        private void UpdateDataCoordinator(UpdateStaffUser command)
        {
            Apply(new DataCoordinatorUpdated(
                command.StaffUserId, command.FullName, command.DisplayName,
                command.Email, command.GpsLocation.Latitude, command.GpsLocation.Longitude,
                command.NationalSociety, (int)command.PreferedLanguage
                ));

            
        }
        private void UpdateDataOwner(UpdateStaffUser command)
        {
            Apply(new DataOwnerUpdated(
                command.StaffUserId, command.FullName, command.DisplayName,
                command.Email, command.GpsLocation.Latitude, command.GpsLocation.Longitude,
                command.NationalSociety, (int)command.PreferedLanguage, command.Position
                ));

        }
        private void UpdateDataVerifier(UpdateStaffUser command)
        {
            Apply(new DataVerifierUpdated(
                command.StaffUserId, command.FullName, command.DisplayName,
                command.Email, command.GpsLocation.Latitude, command.GpsLocation.Longitude,
                command.NationalSociety, (int)command.PreferedLanguage
                ));

        }
        private void UpdateSystemCoordinator(UpdateStaffUser command)
        {
            Apply(new SystemCoordinatorUpdated(
                command.StaffUserId, command.FullName, command.DisplayName,
                command.Email, command.GpsLocation.Latitude, command.GpsLocation.Longitude,
                command.NationalSociety, (int)command.PreferedLanguage
                ));
        }

        #endregion
    }
}
