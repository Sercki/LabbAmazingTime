namespace AT.Common.DTOs;

public record ClickModel(string PageType, int Id);

public record ClickReferenceModel(string PageType, int firstId, int secondId, string firstString, string secondString);
