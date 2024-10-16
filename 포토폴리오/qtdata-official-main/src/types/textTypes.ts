export interface IText {
  content: string;
  fontSize?: string;
  fontFamily?: string;
  fontWeight?: string;
  className?: string;
  padding?: string;
  margin?: string;
  color?: string;
  lineHeight?: string;

  style?: {
    cursor?: string;
    color?: string;
  };

  customStyle?: React.CSSProperties;
  onClick?: () => void;
}

export interface IContentProps {
  content: string;
  fontWeight?: string;
  lineHeight?: string;
  fontSize?: string;
}

export interface TextProps extends IContentProps {
  color?: string | undefined;
}
