import { EventEmitter } from "protractor";

export interface TableActionsModel {
  actionType: string;
  tooltip: string;
  url?: string;
}