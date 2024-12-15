using System.ComponentModel;
using System.IO;

using StreamReader reader = new("../../../input.txt");
string text = reader.ReadToEnd();

string[] reports = text.Split('\n');

int safeReports = 0;

bool EvaluateLevelSafety(int j1, int j2, bool sequenceDecreasing) {
    int delta = j2 - j1;
    bool gradual = Math.Abs(delta) >= 1 && Math.Abs(delta) <= 3;
    bool continuing = delta < 0 == sequenceDecreasing;

    return gradual && continuing;
}

foreach (string report in reports) {
    string[] s = report.Split(' ');
    (int j1, int j2) = (int.Parse(s[0]), int.Parse(s[1]));

    if (Math.Abs(j2 - j1) > 3 || Math.Abs(j2 - j1) < 1) {
        continue;
    }

    bool sequenceIsDecreasing = (j2 - j1) < 0;
    int unsafeLevels = 0;
    for (int i = 1; i < s.Length - 1; i++) {
        if (!EvaluateLevelSafety(int.Parse(s[i]), int.Parse(s[i+1]), sequenceIsDecreasing)) {
            unsafeLevels++;
            i++;
        }

        if (unsafeLevels > 1) {
            break;
        }

        if (i == s.Length - 2) {
            safeReports++;
        }
    }
}

Console.Write(safeReports);