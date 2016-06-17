/* */ 
var Enumerable = require('../linq');
console.log('\nfirst step of Lambda Expression\n');
Enumerable.range(1, 3).select(function(value, index) {
  return index + ':' + value;
}).log().toJoinedString();
Enumerable.range(1, 3).select("value,index=>index+':'+value").log().toJoinedString();
Enumerable.range(1, 3).select("i=>i*2").log().toJoinedString();
Enumerable.range(1, 3).select("$*2").log().toJoinedString();
Enumerable.range(4, 7).join(Enumerable.range(8, 5), "", "", "outer,inner=>outer*inner").log().toJoinedString();
console.log('\nScope of lambda expression\n');
var number = 3;
Enumerable.range(1, 10).where(function(i) {
  return i == number;
}).log().toJoinedString();
console.log('\nfrom(Object) -> convert to keyvaluePair\n');
var object = {
  foo: "a",
  "bar": 100,
  "foobar": true
};
Enumerable.from(object).forEach(function(obj) {
  console.log(obj.key + ":" + obj.value);
});
console.log('\nforEach (continue and break)\n');
Enumerable.repeat("foo", 10).forEach(function(value, index) {
  if (index % 2 == 0)
    return;
  if (index > 6)
    return false;
  console.log(index + ":" + value);
});
console.log('\nGrouping and ref/value comparen\n');
console.log((new Date(2000, 1, 1) == new Date(2000, 1, 1)));
console.log(({a: 0} == {a: 0}));
console.log("------");
var objects = [{
  Date: new Date(2000, 1, 1),
  Id: 1
}, {
  Date: new Date(2010, 5, 5),
  Id: 2
}, {
  Date: new Date(2000, 1, 1),
  Id: 3
}];
Enumerable.from(objects).groupBy("$.Date", "$.Id", function(key, group) {
  return {
    date: key,
    ids: group.toJoinedString(',')
  };
}).log("$.date + ':' + $.ids").toJoinedString();
console.log("------");
Enumerable.from(objects).groupBy("$.Date", "$.Id", function(key, group) {
  return {
    date: key,
    ids: group.toJoinedString(',')
  };
}, function(key) {
  return key.toString();
}).log("$.date + ':' + $.ids").toJoinedString();
console.log('\nRegular Expression matches\n');
var input = "abcdefgABzDefabgdg";
Enumerable.matches(input, "ab(.)d", "i").forEach(function(match) {
  for (var prop in match) {
    console.log(prop + " : " + match[prop]);
  }
  console.log("toString() : " + match.toString());
  console.log("---");
});
console.log('\nLazyEvaluation and InfinityList\n');
var result = Enumerable.toInfinity(1).where("r=>r*r*Math.PI>10000").first();
console.log(result);
console.log('\nDictionary\n');
var cls = function(a, b) {
  this.a = a;
  this.b = b;
};
var instanceA = new cls("a", 100);
var instanceB = new cls("b", 2000);
var dict = Enumerable.empty().toDictionary();
var dict = Enumerable.empty().toDictionary("", "", function(x) {
  return x.a + x.b;
});
dict.add(instanceA, "zzz");
dict.add(instanceB, "huga");
console.log(dict.get(instanceA));
console.log(dict.get(instanceB));
dict.toEnumerable().forEach(function(kvp) {
  console.log(kvp.key.a + ":" + kvp.value);
});
console.log('\nNondeterministic Programs\n');
var apart = Enumerable.range(1, 5);
var answers = apart.selectMany(function(baker) {
  return apart.selectMany(function(cooper) {
    return apart.selectMany(function(fletcher) {
      return apart.selectMany(function(miller) {
        return apart.select(function(smith) {
          return {
            baker: baker,
            cooper: cooper,
            fletcher: fletcher,
            miller: miller,
            smith: smith
          };
        });
      });
    });
  });
}).where(function(x) {
  return Enumerable.from(x).distinct("$.value").count() == 5;
}).where("$.baker != 5").where("$.cooper != 1").where("$.fletcher != 1 && $.fletcher != 5").where("$.miller > $.cooper").where("Math.abs($.smith - $.fletcher) != 1").where("Math.abs($.fletcher - $.cooper) != 1");
answers.selectMany("").log("$.key + ':' + $.value").toJoinedString();
