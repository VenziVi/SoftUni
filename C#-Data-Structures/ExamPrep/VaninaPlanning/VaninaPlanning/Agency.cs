namespace _02.VaniPlanning
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Agency : IAgency
    {
        private Dictionary<string, Invoice> invoiceByNumber;

        public Agency()
        {
            this.invoiceByNumber = new Dictionary<string, Invoice>();
        }

        public void Create(Invoice invoice)
        {
            if (this.invoiceByNumber.ContainsKey(invoice.SerialNumber))
                throw new ArgumentException();

            this.invoiceByNumber[invoice.SerialNumber] = invoice;
        }

        public void ThrowInvoice(string number)
        {
            if (!this.invoiceByNumber.ContainsKey(number))
                throw new ArgumentException();

            this.invoiceByNumber.Remove(number);
        }

        public void ThrowPayed()
        {
            var payedInvoice = this.invoiceByNumber.Values.Where(i => i.Subtotal == 0).ToList();

            foreach (var invoice in payedInvoice)
            {
                this.invoiceByNumber.Remove(invoice.SerialNumber);
            }
        }

        public int Count()
        {
            return this.invoiceByNumber.Count;
        }

        public bool Contains(string number)
        {
            return this.invoiceByNumber.ContainsKey(number);
        }

        public void PayInvoice(DateTime due)
        {
            var InvoiceToPay = this.invoiceByNumber.Values.Where(i => i.DueDate == due).ToList();

            if (InvoiceToPay.Count == 0)
                throw new ArgumentException();

            foreach (var invoice in InvoiceToPay)
            {
                this.invoiceByNumber[invoice.SerialNumber].Subtotal = 0;
            }
        }

        public IEnumerable<Invoice> GetAllInvoiceInPeriod(DateTime start, DateTime end)
        {
            return this.invoiceByNumber
                .Values
                .Where(i => i.IssueDate.Date >= start.Date && i.IssueDate.Date <= end.Date)
                .OrderBy(i => i.IssueDate)
                .ThenBy(i => i.DueDate);
        }

        public IEnumerable<Invoice> SearchBySerialNumber(string serialNumber)
        {
            var result = this.invoiceByNumber
                .Where(i => i.Key.Contains(serialNumber))
                .OrderByDescending(i => i.Value.SerialNumber)
                .Select(i => i.Value)
                .ToList();

            if (result.Count == 0) throw new ArgumentException();

            return result;
        }

        public IEnumerable<Invoice> ThrowInvoiceInPeriod(DateTime start, DateTime end)
        {
            var invoceToThrow = this.invoiceByNumber
                .Values
                .Where(i => i.DueDate.Date > start.Date && i.DueDate.Date < end.Date)
                .ToList();

            if (invoceToThrow.Count == 0) throw new ArgumentException();

            foreach (var invoice in invoceToThrow)
            {
                this.invoiceByNumber.Remove(invoice.SerialNumber);
            }

            return invoceToThrow;
        }

        public IEnumerable<Invoice> GetAllFromDepartment(Department department)
        {
            return this.invoiceByNumber
                .Select(i => i.Value)
                .Where(i => i.Department == department)
                .OrderByDescending(i => i.Subtotal)
                .ThenBy(i => i.IssueDate);
        }

        public IEnumerable<Invoice> GetAllByCompany(string company)
        {
            return this.invoiceByNumber
                .Select(i => i.Value)
                .Where(i => i.CompanyName == company)
                .OrderByDescending(i => i.SerialNumber);
        }

        public void ExtendDeadline(DateTime dueDate, int days)
        {
            var currInvoice = this.invoiceByNumber
                .Values
                .Where(i => i.DueDate.Date == dueDate.Date);

            if (currInvoice.Count() == 0)
                throw new ArgumentException();

            foreach (var invoice in currInvoice)
            {
                invoice.DueDate = invoice.DueDate.AddDays(days); 
            }
        }
    }
}
