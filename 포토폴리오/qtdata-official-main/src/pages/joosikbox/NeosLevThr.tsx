import React from "react";
import { INeosLevThrItemProps } from "../../types/neosTypes";
import {
  LevThrBg,
  LevThrBox,
  LevThrContents,
  LevThrDesc,
  LevThrImg,
  LevThrName,
  NeosLevThrWrap,
  NeosArrowTag,
} from "../../styles/joosikbox/neos";

const NeosLevThrItem: React.FC<INeosLevThrItemProps> = ({ desc, link }) => (
  <LevThrBox>
    <LevThrContents>
      <LevThrName>
        <LevThrImg src="/assets/neos.svg" alt="neos" />
        <LevThrDesc>{desc}</LevThrDesc>
      </LevThrName>
    </LevThrContents>
    {link && (
      <div style={{ width: "200px", zIndex: "2" }}>
        <NeosArrowTag href={link}>
          qtdata.com
          <img
            style={{ width: "60px", height: "40px", marginLeft: "20px" }}
            src="/assets/arrow-right.svg"
            alt="arrow"
          />
        </NeosArrowTag>
      </div>
    )}
  </LevThrBox>
);

const NeosLevThr: React.FC = () => {
  return (
    <NeosLevThrWrap>
      <LevThrBg />
      <NeosLevThrItem desc="Investments LLC" />
      <NeosLevThrItem desc="Digital Asset Management LLC" link="/" />
    </NeosLevThrWrap>
  );
};

export default NeosLevThr;
