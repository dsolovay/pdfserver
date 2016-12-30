import * as React from "react";
import RaisedButton from 'material-ui/RaisedButton';

export interface HelloProps { compiler: string; framework: string; }

export const Hello = (props : HelloProps) => <RaisedButton label="button!" />