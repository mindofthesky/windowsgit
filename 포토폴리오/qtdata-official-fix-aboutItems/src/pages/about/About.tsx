import { useState } from "react";
import { aboutMembers } from "../../datas/aboutItems";
import { TMember, TMemberData } from "../../types/aboutTypes";
import AboutLeader from "./AboutLeader";
import AboutMember from "./AboutMember";
import AboutOurPartner from "./AboutOurPartner";
import AboutSlider from "./AboutSlider";
import AboutOrgan from "./AboutOrgan";
import AboutIdentity from "./AboutIdentity";
import {
  AboutContainer,
  AboutLayout,
  AboutLeaderBox,
} from "../../styles/about/about";
import {
  AboutIntroWrap,
  AboutSliderLayout,
  AboutSliderWrap,
} from "../../styles/about/aboutOurNewsStyle";

const About = () => {
  const [infoMembers, setInfoMembers] = useState<TMemberData[]>(aboutMembers);

  const selectCard = (e: React.MouseEvent, selectedMember: TMember) => {
    const { className: index } = e.currentTarget;

    const [rowIndex, memberIndex] = index.split("/");

    const copyMembers = [...infoMembers];
    copyMembers[0].members.push(selectedMember);
    const leader = copyMembers[0].members.shift();
    if (leader) {
      copyMembers[Number(rowIndex)].members[Number(memberIndex)] = leader;
    }
    setInfoMembers(copyMembers);
  };

  return (
    <AboutLayout>
      <div>
        <div>
          <AboutContainer>
            <AboutLeaderBox>
              <AboutLeader infoMembers={infoMembers} />
              <AboutMember selectCard={selectCard} infoMembers={infoMembers} />
            </AboutLeaderBox>
          </AboutContainer>
        </div>
        {/* 모바일 버전 위치 */}
        <AboutSliderLayout>
          <AboutSliderWrap>
            {/* 여기 였음 */}
            <AboutSlider />
          </AboutSliderWrap>
        </AboutSliderLayout>
        <AboutOrgan />
        <AboutIdentity />
        <AboutOurPartner />
        <AboutIntroWrap></AboutIntroWrap>
        {/* <AboutNews /> */}
      </div>
    </AboutLayout>
  );
};

export default About;
