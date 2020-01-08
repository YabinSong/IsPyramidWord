public boolean isPyramidWord(String word) {

  HashMap<Character, Integer> occurances = new HashMap<Character, Integer>();

  for (int i = 0; i < word.length(); i++) {
    char c = word.charAt(i);
    int count = occurances.containsKey(c) ? occurances.get(c) : 0;
    occurances.put(c, count + 1);
  }

  Object[] values = occurances.values().toArray();
  Arrays.sort(values);

  for (int i = 0; i < values.length; i++) {
    if ((int)values[i] != i + 1) {
      return false;
    }
  }
  return true;
}
