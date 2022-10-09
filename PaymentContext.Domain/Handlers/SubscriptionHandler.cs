using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using System;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler : Notifiable<Notification>, IHandler<CreateBoletoPaymentCommand>, IHandler<CreatePayPalPaymentCommand>
    {
        public readonly IStudentRepository _repository;
        public readonly IEmailService _emailService;

        public SubscriptionHandler(IStudentRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateBoletoPaymentCommand command)
        {
            command.validate();
            if (!command.IsValid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possivel realizar o cadastro");
            }

            if (_repository.DocumentExist(command.Document))
                AddNotification("Document", "This document is arealdy used");

            if (_repository.EmailExist(command.Email))
                AddNotification("Email", "This Email is arealdy used");

            var name = new Name(command.FirstName, command.LastName);
            var doc = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.ZipCode);

            var student = new Student(name, doc, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new BoletoPayment(command.PaidDate, command.ExpiredDate, command.Total, command.TotalPaid, address, new Document(command.PayerDocument, command.PayerDocumentType), command.Payer, email, command.BarCode, command.BoletoNumber);

            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            AddNotifications(name, doc, email, address, student, subscription, payment);

            _emailService.Send(student.Name.ToString(), student.Email.Address, "Welcome to Balta.io", "Our subscription has been created");



            return new CommandResult(true, "");
        }

        public ICommandResult Handle(CreatePayPalPaymentCommand command)
        {
            command.validate();
            if (!command.IsValid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possivel realizar o cadastro");
            }

            if (_repository.DocumentExist(command.Document))
                AddNotification("Document", "This document is arealdy used");

            if (_repository.EmailExist(command.Email))
                AddNotification("Email", "This Email is arealdy used");

            var name = new Name(command.FirstName, command.LastName);
            var doc = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.ZipCode);

            var student = new Student(name, doc, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new PayPalPayment(command.PaidDate, command.ExpiredDate, command.Total, command.TotalPaid, address, new Document(command.PayerDocument, command.PayerDocumentType), command.Payer, email, command.TransactionCode);

            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            AddNotifications(name, doc, email, address, student, subscription, payment);

            _emailService.Send(student.Name.ToString(), student.Email.Address, "Welcome to Balta.io", "Our subscription has been created");

            return new CommandResult(true, "");
        }
    }
}
