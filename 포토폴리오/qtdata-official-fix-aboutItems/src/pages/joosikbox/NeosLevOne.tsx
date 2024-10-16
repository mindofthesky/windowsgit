import React from "react";
import {
  LevOneBg,
  LevOneDesc,
  LevOneDescBox,
  LevOneDescWrap,
  LevOneImgWrap,
  LevOneName,
  LevOneTitle,
  MLevOneBg,
  MLevOneDesc,
  MLevOneLayout,
  MNeosLogoImg,
  NeosLevOneWrap,
} from "../../styles/joosikbox/neos";

const NeosLevOne = () => {
  return (
    <NeosLevOneWrap>
      <LevOneImgWrap>
        <LevOneBg src="/assets/enos-bg.png" alt="bg" />
      </LevOneImgWrap>
      <LevOneDescWrap>
        <div>
          <LevOneTitle>
            <div>Next Generation</div>
            <div>Asset Management</div>
          </LevOneTitle>
        </div>
        <LevOneDescBox>
          <LevOneName>NEOS</LevOneName>
          <LevOneDesc>
            <div>웨이브릿지가 차세대 자산운용업을 실행하고 성장시키기 위해</div>

            <div>핵심 전력을 모아 미국에 설립한 합작법인 자산운용사입니다.</div>
          </LevOneDesc>
        </LevOneDescBox>
      </LevOneDescWrap>
      <MLevOneLayout>
        <MNeosLogoImg src="/assets/neos_gray.png" alt="neos" />
        <MLevOneBg src="/assets/enos-bg-m.png" alt="neoslogo" />
        <MLevOneDesc style={{ width: "90%", textAlign: "center" }}>
          NEOS는 웨이브릿지가 차세대 자산운용업을 실행하고 성장시키기 위해 핵심
          전력을 모아 미국에 설립한 합작법인 자산운용사입니다.
        </MLevOneDesc>
      </MLevOneLayout>
    </NeosLevOneWrap>
  );
};

export default NeosLevOne;
