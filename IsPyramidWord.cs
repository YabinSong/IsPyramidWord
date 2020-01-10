[HttpGet]
// In real world there should be some authentication going on for example with another attribute here [AuthorizeUser], that validates an access token
public HttpResponseMessage IsPyramidWord(string word)
{
    // In real world this algorithm probably would be wrapped into a service and simply called from here
    // something like: bool isPyramidWord = someService.IsPyramidWord(word);
    // then: return Request.CreateResponse(HttpStatusCode.OK, isPyramidWord);
    Dictionary<char, int> occurances = new Dictionary<char, int>();

    for (int i = 0; i < word.Length; i++)
    {
        char key = word.ElementAt(i);
        if (occurances.TryGetValue(key, out int count))
        {
            occurances[key] = ++count;
        }
        else
        {
            occurances.Add(key, ++count);
        }
    }

    int[] values = occurances.Values.ToArray();
    Array.Sort(values);

    for (int i = 0; i < values.Length; i++)
    {
        Console.WriteLine(values[i]);
        if (values[i] != i + 1)
        {
            return Request.CreateResponse(HttpStatusCode.OK, false);
        }
    }
    return Request.CreateResponse(HttpStatusCode.OK, true);
}
