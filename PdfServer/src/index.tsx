import * as React from "react";
import * as ReactDOM from "react-dom";
import * as injectTapEventPlugin from 'react-tap-event-plugin';

injectTapEventPlugin();

import getMuiTheme from 'material-ui/styles/getMuiTheme';
import { MuiThemeProvider, lightBaseTheme } from "material-ui/styles";
import { Hello } from "./components/hello";

const lightMuiTheme = getMuiTheme(lightBaseTheme);

ReactDOM.render(
    <MuiThemeProvider muiTheme={lightMuiTheme}>
        <Hello compiler="typescript" framework="asp.net" />
    </MuiThemeProvider>,
    document.getElementById("example")
)