using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Graph;



using System;

namespace Titan.Plugin.Caffe.Parser {



public partial class Parser {
	public const int _EOF = 0;
	public const int _ident = 1;
	public const int _floatcon = 2;
	public const int _intcon = 3;
	public const int _string = 4;
	public const int _true = 5;
	public const int _false = 6;
	public const int _colon = 7;
	public const int _lbrace = 8;
	public const int _rbrace = 9;
	public const int maxT = 10;

	const bool _T = true;
	const bool _x = false;
	const int minErrDist = 2;
	
	public Scanner scanner;
	public Errors  errors;

	public Token t;    // last recognized token
	public Token la;   // lookahead token
	int errDist = minErrDist;



	public void Initialize(Scanner scanner) {
		this.scanner = scanner;
		errors = new Errors();
	}

	void SynErr (int n) {
		if (errDist >= minErrDist) errors.SynErr(la.line, la.col, n);
		errDist = 0;
	}

	public void SemErr (string msg) {
		if (errDist >= minErrDist) errors.SemErr(t.line, t.col, msg);
		errDist = 0;
	}
	
	void Get () {
		for (;;) {
			t = la;
			la = scanner.Scan();
			if (la.kind <= maxT) { ++errDist; break; }

			la = t;
		}
	}
	
	void Expect (int n) {
		if (la.kind==n) Get(); else { SynErr(n); }
	}
	
	bool StartOf (int s) {
		return set[s, la.kind];
	}
	
	void ExpectWeak (int n, int follow) {
		if (la.kind == n) Get();
		else {
			SynErr(n);
			while (!StartOf(follow)) Get();
		}
	}


	bool WeakSeparator(int n, int syFol, int repFol) {
		int kind = la.kind;
		if (kind == n) {Get(); return true;}
		else if (StartOf(repFol)) {return false;}
		else {
			SynErr(n);
			while (!(set[syFol, kind] || set[repFol, kind] || set[0, kind])) {
				Get();
				kind = la.kind;
			}
			return StartOf(syFol);
		}
	}

	
	void Prototxt() {
		Properties = new Dictionary<string, dynamic>(); 
		string ident = null;
		dynamic value = null;
		
		Statement(out ident, out value);
		InsertValue(ident, value, Properties); 
		while (la.kind == 1) {
			Statement(out ident, out value);
			InsertValue(ident, value, Properties); 
		}
	}

	void Statement(out string ident, out dynamic value) {
		Dictionary<string, dynamic> args = null; 
		dynamic res = null;
		ident = null;
		value = null;
		
		Expect(1);
		ident = t.val; 
		if (la.kind == 7) {
			Property(out res);
			value = res; 
		} else if (la.kind == 8) {
			Compound(out args);
			value = args; 
		} else SynErr(11);
	}

	void Property(out dynamic res) {
		Dictionary<string, dynamic> args = null; 
		res = null;
		
		Expect(7);
		if (StartOf(1)) {
			switch (la.kind) {
			case 4: {
				Get();
				break;
			}
			case 1: {
				Get();
				break;
			}
			case 3: {
				Get();
				break;
			}
			case 2: {
				Get();
				break;
			}
			case 5: {
				Get();
				break;
			}
			case 6: {
				Get();
				break;
			}
			}
			res = t.val; 
		} else if (la.kind == 8) {
			Compound(out args);
			res = args; 
		} else SynErr(12);
	}

	void Compound(out Dictionary<string, dynamic> args) {
		args = new Dictionary<string, dynamic>(); 
		string ident = null;
		dynamic value = null;
		
		Expect(8);
		Statement(out ident, out value);
		InsertValue(ident, value, args); 
		while (la.kind == 1) {
			Statement(out ident, out value);
			InsertValue(ident, value, args); 
		}
		Expect(9);
	}



	public void Run() {
		la = new Token();
		la.val = "";		
		Get();
		Prototxt();
		Expect(0);

	}
	
	static readonly bool[,] set = {
		{_T,_x,_x,_x, _x,_x,_x,_x, _x,_x,_x,_x},
		{_x,_T,_T,_T, _T,_T,_T,_x, _x,_x,_x,_x}

	};
} // end Parser


public class Errors {
	public int count = 0;                                    // number of errors detected
	public System.IO.TextWriter errorStream = Console.Out;   // error messages go to this stream
	public string errMsgFormat = "-- line {0} col {1}: {2}"; // 0=line, 1=column, 2=text

	public virtual void SynErr (int line, int col, int n) {
		string s;
		switch (n) {
			case 0: s = "EOF expected"; break;
			case 1: s = "ident expected"; break;
			case 2: s = "floatcon expected"; break;
			case 3: s = "intcon expected"; break;
			case 4: s = "string expected"; break;
			case 5: s = "true expected"; break;
			case 6: s = "false expected"; break;
			case 7: s = "colon expected"; break;
			case 8: s = "lbrace expected"; break;
			case 9: s = "rbrace expected"; break;
			case 10: s = "??? expected"; break;
			case 11: s = "invalid Statement"; break;
			case 12: s = "invalid Property"; break;

			default: s = "error " + n; break;
		}
		errorStream.WriteLine(errMsgFormat, line, col, s);
		count++;
	}

	public virtual void SemErr (int line, int col, string s) {
		errorStream.WriteLine(errMsgFormat, line, col, s);
		count++;
	}
	
	public virtual void SemErr (string s) {
		errorStream.WriteLine(s);
		count++;
	}
	
	public virtual void Warning (int line, int col, string s) {
		errorStream.WriteLine(errMsgFormat, line, col, s);
	}
	
	public virtual void Warning(string s) {
		errorStream.WriteLine(s);
	}
} // Errors


public class FatalError: Exception {
	public FatalError(string m): base(m) {}
}
}