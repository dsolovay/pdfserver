"use strict";
var React = require("react");
var ReactDOM = require("react-dom");
var nav_1 = require("./components/nav");
var listitem_1 = require("./components/listitem");
ReactDOM.render(React.createElement(nav_1.Nav, { item1: "PDFs", item2: "Settings" }), document.getElementById("nav"));
ReactDOM.render(React.createElement(listitem_1.ListItem, { active: true, selected: true, name: "template 1", tags: "initial", description: "i am just testing" }), document.getElementById("item1"));
//# sourceMappingURL=index.js.map