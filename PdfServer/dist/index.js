"use strict";
var React = require("react");
var ReactDOM = require("react-dom");
var injectTapEventPlugin = require("react-tap-event-plugin");
injectTapEventPlugin();
var getMuiTheme_1 = require("material-ui/styles/getMuiTheme");
var styles_1 = require("material-ui/styles");
var hello_1 = require("./components/hello");
var lightMuiTheme = getMuiTheme_1.default(styles_1.lightBaseTheme);
ReactDOM.render(React.createElement(styles_1.MuiThemeProvider, { muiTheme: lightMuiTheme },
    React.createElement(hello_1.Hello, { compiler: "typescript", framework: "asp.net" })), document.getElementById("example"));
//# sourceMappingURL=index.js.map