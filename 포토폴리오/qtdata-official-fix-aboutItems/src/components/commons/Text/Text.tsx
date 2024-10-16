import React, { useMemo, memo } from "react";
import { IText } from "../../../types/textTypes";

const Text: React.FC<IText> = (props) => {
  const {
    content,
    fontSize,
    fontFamily,
    fontWeight,
    className,
    padding,
    margin,
    color,
    lineHeight,
    customStyle,
  } = props;

  const style = useMemo(() => {
    return {
      content,
      fontSize,
      fontFamily,
      fontWeight,
      className,
      color,
      padding,
      margin,
      lineHeight,
      ...customStyle,
    };
  }, [
    content,
    fontWeight,
    fontSize,
    fontFamily,
    lineHeight,
    padding,
    className,
    margin,
    color,
    customStyle,
  ]);

  return (
    <span style={style} className={className}>
      {content}
    </span>
  );
};

export default memo(Text);
