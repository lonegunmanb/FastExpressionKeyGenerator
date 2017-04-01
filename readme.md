The project combine two parts, part one come from EntityFramework.Extended(https://github.com/loresoft/EntityFramework.Extended), which provide the Expression Evaluator.
Part two come from Jeffery Zhao's FastLambda Project(http://fastlambda.codeplex.com http://www.cnblogs.com/jeffreyzhao/archive/2009/07/29/expression-tree-fast-evaluation.html), which enchanced Expression Evaluator by speed the evaluation up.

You can get a key represent an expression by calling GetKey() method:
var int1 = 10;
Expression<Func<int, bool>> exp1 = i => i > int1;
var exp = exp1.GetKey(false);

You should get:
"i => (i > 10)"

It can be used to generate a key representing a query so you can intercept the real call to the query provider and ask for cache first, it's performance's better than EntityFramework.Extended's version. 

The following License comes from EntityFramework.Extended. Thanks for LoreSoft and Jeffery Zhao's excellent work!
## License

Copyright (c) 2015, LoreSoft
All rights reserved.

Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:

- Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
- Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
- Neither the name of LoreSoft nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
