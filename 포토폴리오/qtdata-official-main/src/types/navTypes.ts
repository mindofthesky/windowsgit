export interface IPath {
  label: string;
  path: string;
}

export interface IMenuItem {
  label: string;
  path: string;
}

export interface IRecruitMenuItem {
  label: string;
  content: React.ReactNode;
}

export type NavItem = IPath | IMenuItem | IRecruitMenuItem;
