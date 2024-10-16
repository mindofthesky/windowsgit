import React from "react";

export interface IHomeDescProps {
  headlineContent: string;
  lgDescContent: string;
  descContent: string;

  renderContent?: () => React.ReactNode;
  renderImgContent?: () => React.ReactNode;
}

export interface IHomeItemBoxProps {
  itemImgSrc: string;
  itemImgAlt: string;
  itemTitle: string;
  descContent: string;
  titleStyles?: any;
  imageSize?: string;
}
