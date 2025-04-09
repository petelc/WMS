using System;

namespace API.DTOs;

public class AddRequestToBoardDto
{
    public int Id { get; set; }
    public bool SendToBoard { get; set; }
}
