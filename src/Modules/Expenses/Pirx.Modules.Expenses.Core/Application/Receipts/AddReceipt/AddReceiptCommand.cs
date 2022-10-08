using Pirx.Shared.Abstractions.Commands;

namespace Pirx.Modules.Expenses.Core.Application.Receipts.AddReceipt;

public record AddReceiptCommand(DateTime IssueDate, int IssuerId) : ICommand { }
