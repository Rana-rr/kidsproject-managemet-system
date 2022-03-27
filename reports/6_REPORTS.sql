CREATE PROC [reports].[Kid_Info_Foreachdeptartment_rep1]
as
begin 
	begin try
		SELECT d.dept_name,k.*
		FROM Kid as k , Department as d 
		where d.dept_id=k.dept_id 
		order by d.dept_id;

	end try
	begin catch
	    Select 'OPPS error catched ...'+ERROR_MESSAGE() +'at line '+ ERROR_LINE();
	end catch
end

-------------------------------------------------------------------
CREATE PROC [reports].[Kidgrade_Forallcourses_rep2] @kidid int
as
set nocount on
begin
	begin try
		select k.kid_id,c.crs_name,sum(a.Point) grade
		from dbo.Kid as k, Exam.Exam_Kid_Answer as a,dbo.kid_course as kc,dbo.Course as c
		where k.kid_id in(@kidid) and  k.kid_id=a.kid_id and k.kid_id=kc.kid_id and kc.crs_id=c.crs_id 
		group by k.kid_id , c.crs_name
	end try
	begin catch
		Select 'OPPS error catched ...'+ERROR_MESSAGE() +'at line '+ ERROR_LINE();
	end catch
end
-----------------------------------------------------------------------------------------
CREATE PROC [reports].[Numofkids_percourse_perinstructorid_rep3] @insid int
as
begin
	begin try
		select i.ins_id,c.crs_name,count(kc.crs_id) as kid_num
		from Instructor as i,Ins_course as ic,Course as c,kid_course as kc
		where i.ins_id in(@insid) and i.ins_id=ic.ins_id and ic.crs_id=c.crs_id and c.crs_id=kc.crs_id 
		group by i.ins_id, c.crs_name
		end try
	begin catch
		Select 'OPPS error catched ...'+ERROR_MESSAGE() +'at line '+ ERROR_LINE();
	end catch
end
------------------------------------------------------------------------------------------
CREATE PROC [reports].[Topicnames_per_courseid_rep4] @topid int
as
begin
	begin try
	   select t.top_name,c.crs_id,c.crs_name,c.crs_duration
	   from Course as c
	   join Topic as t on c.crs_id=t.crs_id and t.top_id =@topid
	end try
	begin catch
	    Select 'OPPS error catched ...'+ERROR_MESSAGE() +'at line '+ ERROR_LINE();
	end catch
end
--------------------------------------------------------------------------------------------
CREATE PROC [reports].[Questions_perexamid_rep5] @examid int
as
begin
	begin try
		select ex.exam_id,q.ques_head as All_Questions
		from Exam.Exam as ex , Exam.Exam_Questions as ex_q ,Exam.Question as q
		where ex.exam_id in(@examid) and ex.exam_id=ex_q.exam_id and ex_q.Question_id=q.ques_id 
    end try
	begin catch
	    Select 'OPPS error catched ...'+ERROR_MESSAGE() +'at line '+ ERROR_LINE();
	end catch
end
--------------------------------------------------------------------------------------------
CREATE PROC [reports].[Quetions_Withkidanswers_rep6] @examid int ,@kidid int
as
begin
     begin try
		   select exa.exam_id,exa.kid_id,t1.ques_head,exa.kid_answer
		   from exam.Exam_Kid_Answer as exa
		   join (select exq.exam_id,eq.ques_id,eq.ques_head
		   from exam.Exam_Questions as exq join exam.Question as eq on exq.Question_id=eq.ques_id)as t1
		   on exa.exam_id=t1.exam_id 
		   where exa.exam_id in(@examid) and exa.kid_id in(@kidid)
 
     end try
     begin catch
	       Select 'OPPS error catched ...'+ERROR_MESSAGE() +'at line '+ ERROR_LINE();

     end catch
end
