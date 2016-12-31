/******/ (function(modules) { // webpackBootstrap
/******/ 	// The module cache
/******/ 	var installedModules = {};
/******/
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/
/******/ 		// Check if module is in cache
/******/ 		if(installedModules[moduleId])
/******/ 			return installedModules[moduleId].exports;
/******/
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = installedModules[moduleId] = {
/******/ 			exports: {},
/******/ 			id: moduleId,
/******/ 			loaded: false
/******/ 		};
/******/
/******/ 		// Execute the module function
/******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);
/******/
/******/ 		// Flag the module as loaded
/******/ 		module.loaded = true;
/******/
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/
/******/
/******/ 	// expose the modules object (__webpack_modules__)
/******/ 	__webpack_require__.m = modules;
/******/
/******/ 	// expose the module cache
/******/ 	__webpack_require__.c = installedModules;
/******/
/******/ 	// __webpack_public_path__
/******/ 	__webpack_require__.p = "";
/******/
/******/ 	// Load entry module and return exports
/******/ 	return __webpack_require__(0);
/******/ })
/************************************************************************/
/******/ ([
/* 0 */
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	var React = __webpack_require__(1);
	var ReactDOM = __webpack_require__(2);
	var nav_1 = __webpack_require__(3);
	var listitem_1 = __webpack_require__(4);
	ReactDOM.render(React.createElement(nav_1.Nav, { item1: "PDFs", item2: "Settings" }), document.getElementById("nav"));
	ReactDOM.render(React.createElement(listitem_1.ListItem, { active: true, selected: true, name: "template 1", tags: "initial", description: "i am just testing" }), document.getElementById("item1"));


/***/ },
/* 1 */
/***/ function(module, exports) {

	module.exports = React;

/***/ },
/* 2 */
/***/ function(module, exports) {

	module.exports = ReactDOM;

/***/ },
/* 3 */
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	var React = __webpack_require__(1);
	exports.Nav = function (props) {
	    return (React.createElement("div", { className: "pure-u" },
	        React.createElement("div", { className: "nav-inner" },
	            React.createElement("button", { className: "primary-button pure-button" }, "New Template"),
	            React.createElement("div", { className: "pure-menu" },
	                React.createElement("ul", { className: "pure-menu-list" },
	                    React.createElement("li", { className: "pure-menu-item" },
	                        React.createElement("a", { href: "#", className: "pure-menu-link" }, props.item1)),
	                    React.createElement("li", { className: "pure-menu-item" },
	                        React.createElement("a", { href: "#", className: "pure-menu-link" }, props.item2)))))));
	};


/***/ },
/* 4 */
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	var __extends = (this && this.__extends) || function (d, b) {
	    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
	    function __() { this.constructor = d; }
	    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
	};
	var React = __webpack_require__(1);
	var ListItem = (function (_super) {
	    __extends(ListItem, _super);
	    function ListItem() {
	        var _this = _super.call(this) || this;
	        _this.state = {
	            selected: false,
	            active: true
	        };
	        return _this;
	    }
	    ListItem.prototype.render = function () {
	        var _this = this;
	        return (React.createElement("div", { className: "list-item " + (this.state.selected ? "list-item-selected " : "") + (this.state.active ? "list-item-unread " : "") + "pure-g", onClick: function () { return _this.setState({ selected: !_this.state.selected, active: _this.state.active }); } },
	            React.createElement("div", { className: "pure-u" },
	                React.createElement("img", { width: "64", height: "64", className: "list-avatar", src: "/img/nodejs-512.png" })),
	            React.createElement("div", { className: "pure-u-3-4" },
	                React.createElement("h5", { className: "list-name" }, this.props.name),
	                React.createElement("h4", { className: "list-subject" }, this.props.tags),
	                React.createElement("p", { className: "list-desc" }, this.props.description))));
	    };
	    return ListItem;
	}(React.Component));
	exports.ListItem = ListItem;


/***/ }
/******/ ]);
//# sourceMappingURL=bundle.js.map