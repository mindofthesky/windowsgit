import { useEffect, useState } from "react";

import Head from "../../components/commons/Headline/Head";
import { recruitItems } from "../../datas/recruitItems";
import {
  RecruitBtnWrap,
  RecruitContainer,
  RecruitItemBox,
  RecruitItemWrap,
  RecruitItems,
  RecruitWrap,
  RecruitTabs,
  RecruitTab,
  RecruitItemName,
  RecruitItemDesc,
  JobBtn,
  SaramBtn,
  JobImg,
  SaramImg,
} from "../../styles/recruit/recuit";
import { HeadlineBox } from "../../styles/about/aboutOurNewsStyle";

const Recruit = () => {
  const [selectedCategory, setSelectedCategory] = useState<string | null>(
    recruitItems.length > 0 ? recruitItems[0].title : null
  );

  useEffect(() => {}, [selectedCategory]);

  return (
    <RecruitWrap>
      <div>
        <RecruitContainer>
          <HeadlineBox>
            <Head content="Teams" />
          </HeadlineBox>
          <RecruitTabs>
            {recruitItems.map((category) => (
              <RecruitTab
                key={category.title}
                onClick={() => setSelectedCategory(category.title)}
                $isselected={selectedCategory === category.title}
              >
                {category.title}
              </RecruitTab>
            ))}
          </RecruitTabs>
          <RecruitItemWrap>
            <div>
              <RecruitItems>
                {recruitItems
                  .filter((category) => selectedCategory === category.title)
                  .map((category) =>
                    category.items.map((item) => (
                      <RecruitItemBox key={item.id}>
                        <RecruitItemName>{item.partName}</RecruitItemName>
                        <RecruitItemDesc>{item.partDesc}</RecruitItemDesc>
                      </RecruitItemBox>
                    ))
                  )}
              </RecruitItems>
            </div>
          </RecruitItemWrap>
          <RecruitBtnWrap>
            <a
              href="https://www.jobkorea.co.kr/Recruit/Co_Read/Recruit/C/41861921?Mem_Sys_No=41861921"
              target="_blank"
              rel="noreferrer"
            >
              <JobBtn>
                <JobImg src="/assets/jobkorea.png" alt="잡코리아" />
              </JobBtn>
            </a>
            <a
              href="https://www.saramin.co.kr/zf_user/company-info/view-inner-recruit?csn=WjdNamVzZDlQeWR3REFyYVd3S3E2Zz09"
              target="_blank"
              rel="noreferrer"
            >
              <SaramBtn>
                <SaramImg src="/assets/saramin.png" alt="사람인" />
              </SaramBtn>
            </a>
          </RecruitBtnWrap>
        </RecruitContainer>
      </div>
    </RecruitWrap>
  );
};

export default Recruit;
