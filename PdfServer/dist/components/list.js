"use strict";
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var React = require("react");
var listitem_1 = require("./listitem");
var fetch = require("whatwg-fetch");
var List = (function (_super) {
    __extends(List, _super);
    function List(props) {
        var _this = _super.call(this, props) || this;
        _this.state.items = Array();
        _this.getItems = _this.getItems.bind(_this);
        return _this;
    }
    List.prototype.getItems = function () {
        fetch('/template/gettemplates')
            .then(function (response) {
            if (response.ok) {
            }
        });
    };
    List.prototype.render = function () {
        var items = this.state.items.map(function (props, index) {
            return (React.createElement(listitem_1.ListItem, { id: index, name: props.name, description: props.description, tags: props.tags, key: index, active: true, selected: true }));
        });
        return (React.createElement("div", { id: "list", className: "pure-u-1" }, items));
    };
    return List;
}(React.Component));
exports.List = List;
//# sourceMappingURL=list.js.map