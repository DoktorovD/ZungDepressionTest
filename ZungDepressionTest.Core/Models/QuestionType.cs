namespace ZungDepressionTest.Core.Models;

public abstract record QuestionType(string Type);

public sealed record Direct() : QuestionType("Прямой");
public sealed record Indirect() : QuestionType("Обратный");