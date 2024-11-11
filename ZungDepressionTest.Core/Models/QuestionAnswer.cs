namespace ZungDepressionTest.Core.Models;

public abstract record QuestionAnswer(byte Value);

public sealed record FirstQuestionAnswer() : QuestionAnswer(1);

public sealed record SecondQuestionAnswer() : QuestionAnswer(2);

public sealed record ThirdQuestionAnswer() : QuestionAnswer(3);

public sealed record FourthQuestionAnswer() : QuestionAnswer(4);

public sealed record EmptyQuestionAnswer() : QuestionAnswer(0);
