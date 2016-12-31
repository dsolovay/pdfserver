import * as React from "react";
import * as ReactDOM from "react-dom";
import { Hello } from "./components/hello";
import { Nav } from "./components/nav";
import { ListItem } from "./components/listitem";

ReactDOM.render(
    <Nav item1="PDFs" item2="Settings" />,
    document.getElementById("nav")
);

ReactDOM.render(
    <ListItem active={true} selected={true} name="template 1" tags="initial" description="i am just testing" />,
    document.getElementById("item1")
);