Lesson 6 - Working with immutable data - pg. 70


6.1 Problems with mutabe data
1. Unrepeatable bug
2. Multithreading pitfalls
3. Accidently sharing state
4. Testing hidden state - complex mock objects

6.3 Answered by working with immutable data
1. You can reason about behavior much more easily. - no hidden state.
2. Function calls are repeatable, functions are pure.
3. Since state is passed to functions, order call is controlable and repeatable
   - each function call is dependent on the output of earlier calls
4. You can see the intermediate value of each step.



