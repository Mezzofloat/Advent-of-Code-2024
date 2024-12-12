using System.IO;

using StreamReader reader = new("../../../input.txt");
string text = reader.ReadToEnd();

string[] reports = text.Split('\n');

int safeReports = 0;
foreach (string report in reports) {
    string[] s = report.Split(' ');
    (int j1, int j2) = (int.Parse(s[0]), int.Parse(s[1]));

    if (Math.Abs(j2 - j1) > 3 || Math.Abs(j2 - j1) < 1) {
        continue;
    }

    bool sequenceIsDecreasing = (j2 - j1) < 0;
    for (int i = 1; i < s.Length - 1; i++) {
        (j1, j2) = (int.Parse(s[i]), int.Parse(s[i+1]));
        int deltaj = j2 - j1;
        if (deltaj < 0 != sequenceIsDecreasing) {
            break;
        }
        if (Math.Abs(deltaj) > 3 || Math.Abs(deltaj) < 1) {
            break;
        }
        if (i == s.Length - 2) {
            safeReports++;
        }
    }
}

Console.Write(safeReports);