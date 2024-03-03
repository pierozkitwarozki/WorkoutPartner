namespace WorkoutPartner.Domain.Database.Enums;

[Flags]
public enum BodyParts
{
    None = 0,
    Head = 1,
    Neck = 2,
    Shoulders = 4,
    Biceps = 8,
    Triceps = 16,
    Forearms = 32,
    Chest = 64,
    UpperBack = 128,
    LowerBack = 256,
    Abs = 512,
    Glutes = 1024,
    HipFlexors = 2048,
    Quads = 4096,
    Hamstrings = 8192,
    Calves = 16384,
    Feet = 32768
}