using Navie_base_spam_mail;
using System.Reflection.PortableExecutable;

var NomalWord = new Dictionary<string, WordInfo>();
var spamWord = new Dictionary<string, WordInfo>();

int totalSpamWord = 0;
int totalNomalWord = 0;
string message = "";
string flag = "sex";
AddWordsToDictionaries(message, flag);
//File fliePath = "spam.csv";

//File.ReadAllLines(filePath);
string[] line = File.ReadAllLines("");
// 파일이 없어서 뜨는 오류로 파일을 지정해주면 됨
double percentageTrainData = 0.70;
int maxline = (int)Math.Floor((double)line.Length * percentageTrainData);
int validationAfter = maxline + 1; // 공백데이터임 
EntryPoint(line, maxline, validationAfter);

void EntryPoint(string[] a, int line, int after)
{
    TrainMode(a, line);
    validationMode(a, after);
}

void TrainMode(string[] a, int line)
{
    foreach (var k in a)
    {
        var splitedLine = k.Split('|', StringSplitOptions.RemoveEmptyEntries);
        var flag = splitedLine[0];
        string message = splitedLine[1].ToLower();

        message = RemovePonctuations(message);
        message = RemoveStopWords(message);
        AddWordsToDictionaries(message, flag);

        Console.WriteLine(flag + " " + message);
        line--;
        if (line <= 0)
            break;
    }

    CalculateProbabilites();
}
void validationMode(string[] a ,int after)
{
    int corretAnswers = 0;
    int wrongAnswers = 0;
    int spanDetectedAsNormal = 0;
    for (int i = after; i< a.Length; i++)
    {
        string[] splitedLine = a[i].Split('|', StringSplitOptions.RemoveEmptyEntries);
        string flag = splitedLine[0];
        string message = splitedLine[1].ToLower();

        message = RemovePonctuations(message);
        message = RemoveStopWords(message);
        if (string.IsNullOrEmpty(message)) continue;

        string[] words = message.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        int position = 0;
        string firstWord = words[position];

        while(NomalWord.ContainsKey(firstWord) == false && position < words.Length) firstWord = words[position++];
        if (position == words.Length) continue;
        var countOFfristWordNomal = NomalWord[firstWord].Quantity;
        var countOFfristSpam = spamWord[firstWord].Quantity;

        double wordbeNomal = countOFfristWordNomal / (countOFfristWordNomal + countOFfristSpam);
        double probTobeNomal = wordbeNomal;

        foreach (var word in words) if (NomalWord.TryGetValue(word, out var value)) probTobeNomal *= value.Probability;

        double probaSpam = countOFfristSpam / (countOFfristSpam + countOFfristWordNomal);
        double proTobeSpam = probaSpam;
        foreach (var word in words) if (spamWord.TryGetValue(word, out var value)) probaSpam *= value.Probability;
        string result = string.Empty;
        if (probTobeNomal > probaSpam) result = "정상메일";
        else result = "스팸";
        Console.WriteLine($"Expected: {flag} -> Result: {result}");
        if (flag.Trim() == result) corretAnswers++;
        else wrongAnswers++;
        if (flag.Trim() == "스팸" && result == "정상메일") spanDetectedAsNormal++;
    }
    Console.WriteLine($"스팸처리 완료: {corretAnswers}");
    Console.WriteLine($"에러: {wrongAnswers}");
    Console.WriteLine($"성공률: {((double)corretAnswers / (double)(corretAnswers + wrongAnswers)) * 100} %");
    Console.WriteLine($"정상 메일로 감지되었으나 스팸메일: {spanDetectedAsNormal}");
}
void CalculateProbabilites()
{
    Console.WriteLine("계산주우우우");
    foreach (var spamWords in spamWord)
    {
        Console.WriteLine(".");
        spamWords.Value.Probability = spamWords.Value.Quantity / totalNomalWord;
    }
    foreach(var nomalWords in NomalWord)
    {
        Console.WriteLine(".");
        nomalWords.Value.Probability = nomalWords.Value.Quantity / totalNomalWord;
    }
}
string RemovePonctuations(string message)
{
    string[] splitedWords = message.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string[] nonstopWords = splitedWords.Except(SpamWord.word).ToArray();
    return string.Join(" ", nonstopWords);
}
string RemoveStopWords(string message)
{
   return new string(message.Where(_ => char.IsPunctuation(_) == false).ToArray());
}
void AddWordsToDictionaries(string message, string flag)
{
    flag = flag.ToLower().Trim();
    Console.WriteLine(flag);
    if(flag == "스팸")
    {
        string[] spliteWord = message.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        foreach (var word in spliteWord)
        {
            totalSpamWord++;
            if (NomalWord.ContainsKey(word) == false) 
            {
                totalNomalWord++;
                spamWord.Add(word, new WordInfo { Quantity = 1 });
            }
            if (spamWord.ContainsKey(word)) spamWord[word].Quantity += 1;
            else spamWord.Add(word,new WordInfo { Quantity = 1 });
        }
    }
    if (flag == "정상메일")
    {
        string[] spliteWord = message.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        foreach(var word in spliteWord)
        {
            totalNomalWord++;
            if(spamWord.ContainsKey(word) == false)
            {
                totalSpamWord++;
                spamWord.Add(word, new WordInfo { Quantity = 1 });
            }
            if (NomalWord.ContainsKey(word)) NomalWord[word].Quantity += 1;
            else NomalWord.Add(word,new WordInfo { Quantity = 1 });
            
        }
    }
}